using UnityEngine;

public class PlatformEnemyDamage : MonoBehaviour
{
    public int damage;
    public PlatformCharacterHealth playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
