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
        ColorDic.Add('g', new Color(239/256f, 100 / 256f, 97 / 256f, 1));
        ColorDic.Add('l', new Color(67 / 256f, 124 / 256f, 144 / 256f, 1));
        ColorDic.Add('r', new Color(237 / 256f, 187 / 256f, 180 / 256f, 1));
        ColorDic.Add('c', new Color(0, 0, 0, 1));
    }

    private void Update()
    {
        if (CurrentDirection != Player.direction)
        {
            CurrentDirection = Player.direction;
            GroundMaterial.color = ColorDic[CurrentDirection];
        }

        if (transform.CompareTag(CurrentDirection.ToString()))
        {
            GroundMaterial.color = Color.white;
        }
    }
}
