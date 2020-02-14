using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioClip mainTheme;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayMusic(mainTheme);
    }
}
