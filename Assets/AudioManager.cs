using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    public AudioClip background;
    public AudioClip paper;
    public AudioClip door;
    public AudioClip grab;
    public AudioClip wall;
    public AudioClip newspaper;

    void Start()
    {
        musicSource.loop = true;    
        musicSource.clip = background;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    
}
    