using UnityEngine;

public class PlatformEnemyDamage : MonoBehaviour
{
    public int damage;
    public PlatformCharacterHealth redHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            redHealth.TakeDamage(damage);
        }
    }
}
