using UnityEditor.SearchService;
using UnityEngine;

public class EndingPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Go to ending scene.
            SceneController.instance.EndingScene();
            Debug.Log("You're winner");
        }
    }
}

