using UnityEngine;

public class PlatformPlayerAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator animator;
    private BoxCollider2D hitbox;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        hitbox =
    transform.Find("HitboxGameObjectName").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) // Attacks when the Left Shift key is pressed.
        {
            animator.SetTrigger("Player_Attack_Animation");
            Invoke("ActivateHitbox", 12f);
            Invoke("DeactiveHitbox", 20f);
        }
    }

    void ActivateHitbox()
    {
        hitbox.gameObject.SetActive(true);
    }

    void DeactiveHitbox()
    {
        hitbox.gameObject.SetActive(false);
    }
}
