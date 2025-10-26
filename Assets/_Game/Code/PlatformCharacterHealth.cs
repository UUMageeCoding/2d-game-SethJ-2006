using UnityEngine;

public class PlatformCharacterHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int redHealth;

    public bool isDead;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        redHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        redHealth -= damage;
        if(redHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("You Are Dead.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (redHealth <= 0 && !isDead)
        {
            isDead = true;
            gameObject.SetActive(false);
            Debug.Log("You Are Dead");
        }
    }

    void OnTriggerEnter2D(Collider2D ether)
    {
        if (gameObject.CompareTag("Collectable"))
        {
            Destroy(gameObject);
        }
    }
}
