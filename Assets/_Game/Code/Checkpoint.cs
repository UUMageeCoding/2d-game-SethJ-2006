using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    PlatformerController platformerController;
    public Transform respawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        platformerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlatformerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            platformerController.UpdateCheckpoint(respawnPoint.position);
            Debug.Log("Checkpoint reached!");
        }
    }
}
