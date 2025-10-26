using UnityEngine;

public class PlatformEnemyDamage : MonoBehaviour
{
    public int damage;
    public playerHealthRed playerHealthR;
    public playerHealthBlue playerHealthB;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player Red")
        {
            playerHealthR.TakeDamage(damage);
        }

        if (collision.gameObject.tag == "Player Blue")
        {
            playerHealthB.TakeDamage(damage);
        }
    }
}
