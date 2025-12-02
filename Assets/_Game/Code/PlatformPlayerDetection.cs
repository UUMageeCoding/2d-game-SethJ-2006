using UnityEngine;

public enum EnemyDetectionModes
{
    Idle,
    Attacking
}

public class PlatformPlayerDetection: MonoBehaviour
{
    public Transform playerPosition;
    int hysteresis = 2;
    SpriteRenderer spriteRenderer;
    public int attackRange;

    public EnemyDetectionModes currentState = EnemyDetectionModes.Idle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerPosition.position);
        switch (currentState)
        {
            case EnemyDetectionModes.Idle:
                if (distanceToPlayer <= attackRange)
                {
                    currentState = EnemyDetectionModes.Attacking;
                    spriteRenderer.color = Color.blueViolet;
                }
                break;

            case EnemyDetectionModes.Attacking:
                if (distanceToPlayer > attackRange + hysteresis)
                {
                    currentState = EnemyDetectionModes.Idle;
                    spriteRenderer.color = Color.white;
                }
                break;
        }
    }
}
