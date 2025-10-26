using UnityEngine;

public class PlatformCharacterHealth : MonoBehaviour
{
    public int maxHealth = 1;
    public int playerHealth;

    public bool isDead;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("You Are Dead.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0 && !isDead)
        {
            isDead = true;
            gameObject.SetActive(false);
            Debug.Log("You Are Dead");
        }
    }
}
