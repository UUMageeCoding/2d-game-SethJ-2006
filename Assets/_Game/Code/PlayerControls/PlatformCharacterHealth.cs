using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlatformCharacterHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int playerHealth;
    [SerializeField] private PlatformerController platformerController;

    AudioManager audioManager;

    // public bool isDead;
    // public int Respawn;

    public TMP_Text healthBarText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = maxHealth;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        audioManager.PlaySFX(audioManager.playerDamaged);
        playerHealth=Mathf.Clamp(playerHealth, 0, maxHealth);
        if(playerHealth <= 0)
        {
            platformerController.Die();
            playerHealth = maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (playerHealth <= 0 && !isDead)
        // {
            // isDead = true;
            // gameObject.SetActive(false);
            // Debug.Log("You Are Dead");
            // SceneManager.LoadScene(Respawn);
        // }

        healthBarText.text = "Health: " + playerHealth + " / 10";
    }

    public void Heal(int healthBack)
    {
        if (playerHealth < 10)
        {
            int maxHeal = Mathf.Max(maxHealth - playerHealth, 0);
            int actualHeal = Mathf.Min(maxHeal, healthBack);
            playerHealth += actualHeal;
            Debug.Log("Health restored!");
        }
    }
}
