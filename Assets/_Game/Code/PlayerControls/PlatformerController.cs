using System;
using System.Collections;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Timeline;

public class PlatformerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 12f;



    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] public bool flipX = false;

    Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    private bool isGrounded;
    private float moveInput;

    public float knockbackForce;
    public float knockbackCounter;
    public float knockbackTotalTime;
    public bool knockbackFromRight;
    Vector2 respawnPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        // Set to Dynamic with gravity
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 3f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        // Set the player's starting position
        respawnPosition = transform.position;
    }

    void Update()
    {
        // Get horizontal input
        moveInput = Input.GetAxisRaw("Horizontal");
        if(moveInput > 0 || moveInput < 0)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }


        if (moveInput > 0)
        {
            sr.flipX = false;
        }
        else if(moveInput < 0)
        {
            sr.flipX = true;
        }
        
        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

       




        // Jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.GetBool("IsGrounded");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        if (knockbackCounter <= 0)
        {
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            if (knockbackFromRight == true)
            {
                rb.linearVelocity = new Vector2(-knockbackForce, knockbackForce);
            }
            if (knockbackFromRight == false)
            {
                rb.linearVelocity = new Vector2(knockbackForce, knockbackForce);
            }

            knockbackCounter -= Time.deltaTime;
        }
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pit"))
        {
            Die();
        }
    }

        public void UpdateCheckpoint(Vector2 pos)
    {
        respawnPosition = pos;
    }

    void Die()
    {
        StartCoroutine(Respawn(1f));
    }
    IEnumerator Respawn(float duration)
    {
        sr.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = respawnPosition;
        sr.enabled = true;
    }



    // Visualise ground check in editor
    void OnDrawGizmosSelected()
        {
            if (groundCheck != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
            }
        }
    }