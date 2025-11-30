using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttackScript : MonoBehaviour

{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetTrigger("PlayerAttackAnimation");
                Invoke("ActivateHitbox", 12f);
                Invoke("DeactiveHitbox", 20f);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyHealth>().currentHealth -= damage;
                }
            }
        
        timeBtwAttack = startTimeBtwAttack;
    } else
    {
        timeBtwAttack -= Time.deltaTime;
    }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.ghostWhite;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
