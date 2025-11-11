using Unity.Profiling;
using UnityEngine;

public enum BigBossState
{
    Idle,
    Attacking

}

public class BigBossAI : MonoBehaviour
{
    // Current state of the Big Boss
    public BigBossState currentState = BigBossState.Idle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
