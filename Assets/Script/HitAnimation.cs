using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAnimation : MonoBehaviour
{
    private ParticleSystem hit;
    private Transform hitTransform;
    private Dictionary<char, Quaternion> Direction = new Dictionary<char, Quaternion>();
    private char CurrentDirection = 'g';

    // Start is called before the first frame update
    void Start()
    {
        hit = GetComponentInChildren<ParticleSystem>();
        hitTransform = GetComponentInChildren<Transform>();
        Direction.Add('g', Quaternion.Euler(90f, 90f, 0f));
        Direction.Add('r', Quaternion.Euler(0, 90f, 0));
        Direction.Add('l', Quaternion.Euler(0, 90f, 0));
        Direction.Add('c', Quaternion.Euler(90f, 90f, 0));
    }

    /*
    void Update()
    {
        CurrentDirection = GetComponent<PlayerControl>().direction;
        hitTransform.rotation = Direction[CurrentDirection];
    }
    */

    private void OnCollisionEnter(Collision collision)
    {
        if(CurrentDirection != GetComponent<PlayerControl>().direction)
        {
            CurrentDirection = GetComponent<PlayerControl>().direction;
            hitTransform.rotation = Direction[CurrentDirection];
            hit.Play();
        }
    }
}
