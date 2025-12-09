using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformAttackHitbox : MonoBehaviour

{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   [SerializeField] Transform attackPos;
   [SerializeField] private SpriteRenderer spriteRenderer;
   [SerializeField] bool flipX = false;
   public float attackRadius = 1f;
   public int damage = 1;
    public LayerMask enemyLayer;

    public PlatformerController sr;
    // public EnemyHealth maxHealth;
    // private void OnTriggerEnter2D(Collider2D collision){if (collision.gameObject.CompareTag("Enemy")){maxHealth.TakeDamage(damage);}}

    [SerializeField] public List<GameObject> enemies;
    
    private void Start()
    {
        Attack();
    }

    void FixedUpdate()
    {
        if(sr.flipX == true)
        {
            spriteRenderer.flipX = true;
        }
        else if(sr.flipX == false)
        {
            spriteRenderer.flipX = false;
        }
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
