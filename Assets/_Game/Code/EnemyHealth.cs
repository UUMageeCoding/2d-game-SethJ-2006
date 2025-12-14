using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float maxHealth;
    public float currentHealth;

    AudioManager audioManager;

    private void Start()
    {
        currentHealth = maxHealth;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        audioManager.PlaySFX(audioManager.enemyDamaged);
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
