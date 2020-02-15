using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Responsible for sound setting
 */
public class SoundLibrary : MonoBehaviour
{
    public enum AudioChannel { Master, Sound, Music };

    public float masterVolume { get; private set; }
    public float musicVolume { get; private set; }
    public float soundVolume { get; private set; }

    public static SoundLibrary Instance { get; private set; }

    public AudioClip ButtionClickSound;
    public AudioClip ButtionHoverSound;
    public AudioClip BackgroundMusic;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        masterVolume = PlayerPrefs.GetFloat("master Vol", 0.5f);
        musicVolume = PlayerPrefs.GetFloat("music Vol", 0.5f);
        soundVolume = PlayerPrefs.GetFloat("sound Vol", 0.5f);

        Debug.Log(masterVolume);
        Debug.Log(musicVolume);
        Debug.Log(soundVolume);

    }

    public void SetVolume(float newVolume, AudioChannel channel)
    {
        switch (channel)
        {
            case AudioChannel.Master:
                masterVolume = newVolume;
                break;
            case AudioChannel.Sound:
                soundVolume = newVolume;
                break;
            case AudioChannel.Music:
                musicVolume = newVolume;
                break;
        }

        AudioManager.musicSources[0].volume = masterVolume * musicVolume;
        AudioManager.musicSources[1].volume = masterVolume * musicVolume;

        PlayerPrefs.SetFloat("master Vol", masterVolume);
        PlayerPrefs.SetFloat("music Vol", musicVolume);
        PlayerPrefs.SetFloat("sound Vol", soundVolume);
        PlayerPrefs.Save();
    }
}
