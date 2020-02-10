using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColor : MonoBehaviour
{
    private Material GroundMaterial;
    private Dictionary<char, Color> ColorDic;
    private char CurrentDirection;
    private PlayerControl Player;

    private void Start()
    {
        GroundMaterial = GetComponent<Renderer>().material;
        CurrentDirection = 'g';
        Player = GameObject.Find("Player").GetComponent<PlayerControl>();
        ColorDic = new Dictionary<char, Color>();
        ColorDic = ColorHolder.PlatformColor;
    }

    private void Update()
    {
        if (CurrentDirection != Player.direction)
        {
            CurrentDirection = Player.direction;
            GroundMaterial.color = ColorDic[CurrentDirection];
        }

        if (transform.CompareTag(Player.direction.ToString()))
        {
            GroundMaterial.color = Color.white;
            return;
        } // Minor optimization?
    }
}
