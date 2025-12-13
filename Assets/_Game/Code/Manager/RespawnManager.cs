using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private static RespawnManager _instance;
    public static RespawnManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI Manager instance is null");
            }
            return _instance;
        }
    }

    public Vector2 respawnPosition;
    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(this);
        
        DontDestroyOnLoad(this);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Pit"))
        {
            Die();
        }
    }
    void Die()
    {
        // StartCoroutine(Respawn(1f));
        // Debug.Log(respawnPosition.ToString());
    }

}
