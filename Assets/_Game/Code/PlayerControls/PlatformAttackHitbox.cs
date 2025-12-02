using System.Collections.Generic;
using UnityEngine;

public class PlatformAttackHitbox : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   [SerializeField] Transform attackPos;
   public float attackRadius = 1f;
   public int damage = 1;
    public LayerMask enemyLayer;
    // public EnemyHealth maxHealth;
    // private void OnTriggerEnter2D(Collider2D collision){if (collision.gameObject.CompareTag("Enemy")){maxHealth.TakeDamage(damage);}}

    [SerializeField] public List<GameObject> enemies;
    
    private void Start()
    {
        Attack();
    }
    
    public void Attack()
    {

        foreach (GameObject enemy in enemies)
        {
            if ((this.transform.position - enemy.transform.position).magnitude < attackRadius)
            {
                EnemyHealth eh = enemy.GetComponent<EnemyHealth>();
                if (eh.currentHealth <= damage)
                {
                    if (enemies.Contains(enemy))
                    {
                        enemies.Remove(enemy);
                    }
                }
                eh.TakeDamage(damage);
            }
        }
        
  

        /*
        Collider[] hitEnemies = Physics.OverlapSphere(attackPos.position, attackRadius, enemyLayer);
        foreach (Collider enemyCollider in hitEnemies)
        {
            IDamageable obj = enemyCollider.GetComponent<IDamageable>();
            if (obj != null)
            {
                obj.TakeDamage(damage);
            }
        }
        */
    }
}
