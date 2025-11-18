using UnityEngine;

public class PlatformEnemyPatrol : MonoBehaviour
{

    public float enemySpeed = 1f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private bool isFacingRight = false; // Moves to the left first.
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        rb.freezeRotation = true; // Won't rotate onto its side.
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float direction = isFacingRight ? 1f : -1f; // 1 = right, -1 = left
        rb.linearVelocity = new Vector2(direction * enemySpeed, rb.linearVelocityY);

        // Flip sprite via SpriteRender; can be commented out.
        sr.flipX = !isFacingRight; // flipX = true when facing left
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // When an enemy hits a 'solid wall', reverse direction
        if (collision.gameObject.CompareTag("solid"))
        {
            isFacingRight = !isFacingRight;
        }
    }
}
