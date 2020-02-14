using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibrary : MonoBehaviour
{

    public static float masterVolume = 1f;
    public static float musicVolume = 0.5f;
    public static float soundVolume = 1f;

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
    }
}
