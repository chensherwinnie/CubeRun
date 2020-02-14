using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script has a execution order of 100
 * which is earlier than the execution order of MusicManager.cs (200)
 */
public  class AudioManager : MonoBehaviour
{
    float masterVolume;
    float musicVolume;
    float soundVolume;

    public AudioSource[] musicSources;
    int activeMusicIndex = 1;

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
        Debug.Log("Start is run");
    }

    public void PlayMusic(AudioClip clip, float fadeDuration = 1)
    {
        Debug.Log("Play music");
        activeMusicIndex = 1 - activeMusicIndex;
        musicSources[activeMusicIndex].clip = clip;
        musicSources[activeMusicIndex].Play();
    }
}
