using UnityEngine;

public class EnemyPatrolScript : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        // When an enemy hits a 'solid wall', reverse direction
        if (col.tag == "Solid")
        {
            isFacingRight = !isFacingRight;
        }
    }
    
}

    /*
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame
    void Update()
    {
        if(patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolPoints[0].position) < 0.2f)
            {
                // transform.localScale = new Vector3(1, 1, 1);
                Vector3 localScale = transform.localScale;
                localScale.x *= -1;
                transform.localScale = localScale;
                patrolDestination = 1;
                transform.position += new Vector3(0.3f, 0, 0);
                Debug.Log("Boing");
            }
        if(patrolDestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolPoints[1].position) < 0.2f)
            {
                // transform.localScale = new Vector3(-1, 1, 1);
                Vector3 localScale = transform.localScale;
                localScale.x *= -1;
                transform.localScale = localScale;
                patrolDestination = 0;
                transform.position += new Vector3(-0.3f, 0, 0);
                Debug.Log("Bounce");
            }
        }
        }
    }
    */