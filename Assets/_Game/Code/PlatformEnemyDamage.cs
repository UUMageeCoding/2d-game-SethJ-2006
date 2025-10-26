using UnityEngine;

public class PlatformEnemyDamage : MonoBehaviour
{
    public int damage = 1;
    public PlatformCharacterHealth playerHealthR;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player Red")
        {
            playerHealthR.TakeDamage(damage);
        }
    }
}
