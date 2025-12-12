using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    PlatformerController platformerController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        platformerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlatformerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            platformerController.UpdateCheckpoint(transform.position);
            Debug.Log("Checkpoint reached!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
