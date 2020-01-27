using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GetComponentInChildren<ParticleSystem>().GetComponent<ParticleSystem>().Play();
        Debug.Log("Trigger");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0.25f, 0);
    }
}
