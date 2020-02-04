using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public Material PlayerMaterial;
    public Dictionary<char, Color> ColorDic;
    private char CurrentDirection;
    private PlayerControl Player;

    private void Start()
    {
        PlayerMaterial = GetComponent<Renderer>().material;
        CurrentDirection = 'g';
        Player = GameObject.Find("Player").GetComponent<PlayerControl>();
        ColorDic = new Dictionary<char, Color>();
        ColorDic.Add('g', new Color(59 / 256f, 53 / 256f, 97 / 256f, 1));
        ColorDic.Add('l', new Color(204 / 256f, 164 / 256f, 59 / 256f, 1));
        ColorDic.Add('r', new Color(7 / 256f, 79 / 256f, 87 / 256f, 1));
        ColorDic.Add('c', new Color(0, 0, 0, 1));
    }

    private void Update()
    {
        if (CurrentDirection != Player.direction)
        {
            CurrentDirection = Player.direction;
            PlayerMaterial.color = ColorDic[CurrentDirection];
        }

        if (transform.CompareTag(CurrentDirection.ToString()))
        {
            PlayerMaterial.color = Color.white;
        }
    }
}
