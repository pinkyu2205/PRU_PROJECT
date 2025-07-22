using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayClip(AudioClip clip, AudioSource source)
    {
        source.clip = clip;
        source.Play();
    }

    public void PlayRandomClip(AudioClip[] clipa, AudioSource source)
    {
        int randomIndex = Random.Range(0, 1);

        source.clip = clipa[randomIndex];
        source.Play();
    }
}
