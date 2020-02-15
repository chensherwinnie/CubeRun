using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenuFunction : MonoBehaviour
{
    public Slider[] volumeSliders;

    private void Start()
    {
        volumeSliders[0].value = SoundLibrary.Instance.masterVolume;
        volumeSliders[1].value = SoundLibrary.Instance.musicVolume;
        volumeSliders[2].value = SoundLibrary.Instance.soundVolume;
        Debug.Log(volumeSliders[0].value);
        Debug.Log(volumeSliders[1].value);
        Debug.Log(volumeSliders[2].value);
    }

    public void AdjustMasterVolume(float volume)
    {
        SoundLibrary.Instance.SetVolume(volume, SoundLibrary.AudioChannel.Master);
    }
    public void AdjustMusicVolume(float volume)
    {
        SoundLibrary.Instance.SetVolume(volume, SoundLibrary.AudioChannel.Music);
    }
    public void AdjustSoundVolume(float volume)
    {
        SoundLibrary.Instance.SetVolume(volume, SoundLibrary.AudioChannel.Sound);
    }
}
