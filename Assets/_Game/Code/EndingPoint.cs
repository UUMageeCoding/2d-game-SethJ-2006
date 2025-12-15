using UnityEngine;

public class EndingPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Go to ending scene.
        }
    }
}

