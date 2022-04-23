using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource musicSource, effectsSource;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void playMusic(AudioClip music)
    {
        musicSource.clip = music;
        musicSource.Play();
    }

    public void playSoundFX(AudioClip clip)
    {
        effectsSource.PlayOneShot(clip);
    }

}