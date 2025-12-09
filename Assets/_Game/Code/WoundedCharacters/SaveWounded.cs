using UnityEngine;

public class SaveWounded : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Mine Worker Saved.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}