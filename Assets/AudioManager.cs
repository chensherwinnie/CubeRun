using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script has a execution order of 100
 * which is earlier than the execution order of MusicManager.cs (200)
 *
 * Responsible for playing sound
 */
public class AudioManager : MonoBehaviour
{

    public static AudioSource[] musicSources;  //used to play background music
    int activeMusicIndex = 1;

    private AudioSource UIsource;   //used to play 2D stound

    public static AudioManager instance;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(instance);
        }

        musicSources = new AudioSource[2];
        for(int i = 0; i < 2; i++)
        {
            GameObject newMusicSource = new GameObject("Music source" + (i + 1));
            musicSources[i] = newMusicSource.AddComponent<AudioSource>();
            newMusicSource.transform.parent = transform;
        }

        UIsource = gameObject.AddComponent<AudioSource>();
    }

    public void PlayMusic(AudioClip clip, float fadeDuration = 2)
    {
        activeMusicIndex = 1 - activeMusicIndex;
        musicSources[activeMusicIndex].clip = clip;
        musicSources[activeMusicIndex].Play();
        StartCoroutine(MusicFadeIn(fadeDuration));
    }

    IEnumerator MusicFadeIn(float second)
    {
        float percent = 0;

        while(percent < 1)
        {
            percent += Time.deltaTime / second * 1f;
            musicSources[activeMusicIndex].volume = Mathf.Lerp(0, SoundLibrary.Instance.musicVolume * SoundLibrary.Instance.masterVolume, percent);
            musicSources[1 - activeMusicIndex].volume = Mathf.Lerp(SoundLibrary.Instance.musicVolume * SoundLibrary.Instance.masterVolume, 0, percent);
            yield return null;
        }
    }

    public void PlaySound()
    {
        //AudioSource.
    }

    public void PlayUISound(AudioClip clip)
    {
        UIsource.volume = SoundLibrary.Instance.soundVolume * SoundLibrary.Instance.masterVolume;
        UIsource.PlayOneShot(clip);
    }
}
