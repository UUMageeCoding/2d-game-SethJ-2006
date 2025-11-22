using UnityEngine;

public class PlatformEnemyDamage : MonoBehaviour
{
    public int damage;
    public PlatformCharacterHealth playerHealth;
    public PlatformerController playerMovement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerMovement.knockbackCounter = playerMovement.knockbackTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                playerMovement.knockbackFromRight = true;
            }
            if(collision.transform.position.x >= transform.position.x)
            {
                playerMovement.knockbackFromRight = false;
            }
            playerHealth.TakeDamage(damage);
        }
    }
}
