using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    PlatformerController platformerController;
    public Transform respawnPoint;

    AudioManager audioManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        platformerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlatformerController>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // platformerController.UpdateCheckpoint(respawnPoint.position);
            audioManager.PlaySFX(audioManager.checkpoint);
            RespawnManager.Instance.respawnPosition = respawnPoint.position;
            Debug.Log("Checkpoint reached!");
        }
    }
}
