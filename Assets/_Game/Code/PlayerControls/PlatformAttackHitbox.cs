using UnityEngine;

public class PlatformAttackHitbox : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public int damage = 1;
   public EnemyHealth currentHealth;
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            currentHealth.TakeDamage(damage);
        }
    }
}
