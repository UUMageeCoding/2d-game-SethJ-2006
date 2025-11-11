using Unity.Profiling;
using UnityEngine;

public enum BigBossState
{
    Idle,
    Attacking

}

public class BigBossAI : MonoBehaviour
{
    public Transform playerPosition;
    int hysteresis = 2;
    SpriteRenderer spriteRenderer;

    public int attackDistance;
    // Current state of the Big Boss
    public BigBossState currentState = BigBossState.Idle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerPosition.position);
    }
}
