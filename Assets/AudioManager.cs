using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script has a execution order of 100
 * which is earlier than the execution order of MusicManager.cs (200)
 */
public class AudioManager : MonoBehaviour
{

    public AudioSource[] musicSources;
    int activeMusicIndex = 1;

    private AudioSource UIsource;


    public static AudioManager instance;

    private void Start()
    {
        instance = this;

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
            musicSources[activeMusicIndex].volume = Mathf.Lerp(0, SoundLibrary.musicVolume * SoundLibrary.masterVolume, percent);
            musicSources[1 - activeMusicIndex].volume = Mathf.Lerp(SoundLibrary.musicVolume * SoundLibrary.masterVolume, 0, percent);
            yield return null;
        }
    }

    public void PlaySound()
    {
        //AudioSource.
    }

    public void PlayUISound(AudioClip clip)
    {
        UIsource.volume = SoundLibrary.soundVolume * SoundLibrary.masterVolume;
        UIsource.PlayOneShot(clip);
    }
}
