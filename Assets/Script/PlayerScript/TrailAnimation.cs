using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailAnimation : MonoBehaviour
{
    Dictionary<char, Quaternion> Direction = new Dictionary<char, Quaternion>();
    private char CurrentDirection = 'g';

    // Start is called before the first frame update
    void Start()
    {
        Direction.Add('g', Quaternion.Euler(0, 0, 0));
        Direction.Add('r', Quaternion.Euler(0, 0, 90));
        Direction.Add('l', Quaternion.Euler(0, 0, -90));
        Direction.Add('c', Quaternion.Euler(90, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentDirection != GameObject.Find("Player").GetComponent<PlayerControl>().direction)
        {
            CurrentDirection = GameObject.Find("Player").GetComponent<PlayerControl>().direction;
            transform.rotation = Direction[CurrentDirection];
        }
    }
}
