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
    // Vector2 respawnPosition;
    AudioManager audioManager;

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
        transform.position = RespawnManager.Instance.respawnPosition;
    }
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
            animator.SetBool("IsGrounded", false);
            audioManager.PlaySFX(audioManager.jump);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
        if (isGrounded)
        {
            animator.SetBool("IsGrounded", true);
        }
        else
        {
            animator.SetBool("IsGrounded", false);
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

        //public void UpdateCheckpoint(Vector2 pos)
    //{
        //respawnPosition = pos;
    //}

    public void Die()
    {
        StartCoroutine(Respawn(2f));
        // Debug.Log(respawnPosition.ToString());
    }
    IEnumerator Respawn(float duration)
    {
        //sr.enabled = false;
        audioManager.PlaySFX(audioManager.playerDeath);
        //animator.SetTrigger("PlayerDied");
        moveSpeed = 0f;
        jumpForce = 0f;
        knockbackCounter = 0;
        rb.gravityScale = 0f;
            transform.localScale = new Vector3(0, 0, 1);
        yield return new WaitForSeconds(duration);
        transform.position = RespawnManager.Instance.respawnPosition;
        //sr.enabled = true;
        moveSpeed = 7f;
        jumpForce = 12f;
        rb.gravityScale = 3f;
            transform.localScale = new Vector3(2, 2, 1);
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