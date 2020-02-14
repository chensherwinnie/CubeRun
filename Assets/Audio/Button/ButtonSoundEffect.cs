using UnityEngine;

/*
 * These functions should only be used by buttons
 */
public class ButtonSoundEffect : MonoBehaviour
{

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    public void PlayClickSound()
    {
        PlaySound(SoundLibrary.Instance.ButtionClickSound);
    }

    public void PlayHoverSound()
    {
        PlaySound(SoundLibrary.Instance.ButtionHoverSound);
    }

    void PlaySound(AudioClip clip)
    {
        AudioManager.instance.PlayUISound(clip);
    }
}
