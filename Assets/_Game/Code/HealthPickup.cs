using UnityEngine;

public class HealthPickup : MonoBehaviour

{
    public int healthBack;
    public PlatformCharacterHealth playerHealth;

    AudioManager audioManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerHealth.Heal(healthBack);
            audioManager.PlaySFX(audioManager.heal);
            Destroy(gameObject);
        }
    }
}
