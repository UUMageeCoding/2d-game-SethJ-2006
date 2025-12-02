using UnityEngine;

public class HealthPickup : MonoBehaviour

{
    public int healthBack = 10;
    public PlatformCharacterHealth playerHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerHealth.Heal(healthBack);
            Destroy(gameObject);
        }
    }
}
