using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EnableEffect : MonoBehaviour
{
    private void Update()
    {
        if (GameObject.Find("Player").GetComponent<TimeBody>().isRewinding)
        {
            GetComponent<PostProcessVolume>().enabled = true;
        }
        else
        {
            GetComponent<PostProcessVolume>().enabled = false;
        }
    }
}
