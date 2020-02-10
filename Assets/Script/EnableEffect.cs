using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


/*
 * Enable the special camera effect if isRewinding is true
 * Used by PostProcessing Object in Camera
 * (Time Body Script exists in GameManager empty object)
 */
public class EnableEffect : MonoBehaviour
{
    ColorGrading colorGradingLayer = null;

    private Color OGColorFilter = new Color(174 / 256f, 254 / 256f, 255 / 256f, 1);
    private Color DeadColorFilter = new Color(1, 0, 0, 0.5f);

    private void Start()
    {
        GetComponent<PostProcessVolume>().profile.TryGetSettings(out colorGradingLayer);
    }

    private void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<TimeBody>().PlayerIsDead)
        {
            colorGradingLayer.brightness.Interp(1, 1, 0f);
            colorGradingLayer.colorFilter.Interp(DeadColorFilter, DeadColorFilter, 0f);
        }
        else
        {
            colorGradingLayer.brightness.Interp(7, 7, 0f);
            colorGradingLayer.colorFilter.Interp(OGColorFilter, OGColorFilter, 0f);
        }

        if (GameObject.Find("GameManager").GetComponent<TimeBody>().isRewinding)
        {
            GetComponent<PostProcessVolume>().enabled = true;
        }
        else
        {
            GetComponent<PostProcessVolume>().enabled = false;
        }
    }
}
