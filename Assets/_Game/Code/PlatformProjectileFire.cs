using UnityEngine;

public class PlatformProjectileFire : MonoBehaviour
{
    public GameObject projectile;
    public Transform projectilePos;
    private float cooldownTimer;

    AudioManager audioManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer > 4)
        {
            cooldownTimer = 0;
            shoot();
        }
    }
    
    void shoot()
    {
        Instantiate(projectile, projectilePos.position, Quaternion.identity);
        audioManager.PlaySFX(audioManager.enemyFire);
    }
}
