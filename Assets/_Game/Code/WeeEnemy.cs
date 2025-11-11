using UnityEngine;
using UnityEngine.UIElements;

public class WeeEnemy : MonoBehaviour
{
    public Transform playerPosition;
    Vector2 directionToPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get direction to player
        if (playerPosition != null)
        {        
        directionToPlayer = (playerPosition.position - transform.position).normalized;
        Debug.Log(directionToPlayer);
        }
    }
}
