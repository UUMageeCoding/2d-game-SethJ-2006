using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("---Audio Source---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("---Audio Clips---")]
    public AudioClip background;
    public AudioClip jump;
    public AudioClip playerAttack;
    public AudioClip playerDeath;
    public AudioClip enemyFire;
    public AudioClip heal;
    public AudioClip rescue;

    private void Start()
    {
        musicSource.clip=background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
