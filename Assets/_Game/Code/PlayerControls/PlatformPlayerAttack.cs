using UnityEngine;

public class PlatformPlayerAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Animator animator;
    private BoxCollider2D hitbox;
    public PlatformAttackHitbox dmgHitbox;

    AudioManager audioManager;
    private void Start()
    {
        animator = GetComponent<Animator>();
        hitbox = transform.Find("AttackHitbox").GetComponent<BoxCollider2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) // Attacks when the Left Shift key is pressed.
        {
            animator.SetTrigger("PlayerAttackAnimation");
            Invoke("ActivateHitbox", 12f);
            audioManager.PlaySFX(audioManager.playerAttack);
            Invoke("DeactiveHitbox", 20f);
            dmgHitbox.Attack();
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
