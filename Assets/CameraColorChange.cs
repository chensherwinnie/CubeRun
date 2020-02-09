using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorChange : MonoBehaviour
{
    private Camera CurrentCamera;
    private Dictionary<char, Color> ColorDic;
    private char CurrentDirection;
    private PlayerControl Player;

    private void Start()
    {
        CurrentCamera = GetComponent<Camera>();
        CurrentDirection = 'g';
        Player = GameObject.Find("Player").GetComponent<PlayerControl>();
        ColorDic = new Dictionary<char, Color>();
        ColorDic.Add('g', new Color(228 / 256f, 179 / 256f, 99 / 256f, 1));
        ColorDic.Add('l', new Color(37 / 256f, 89 / 256f, 87 / 256f, 1));
        ColorDic.Add('r', new Color(121 / 256f, 123 / 256f, 132 / 256f, 1));
        ColorDic.Add('c', new Color(230 / 256f, 230 / 256f, 233 / 256f, 1));
    }

    private void Update()
    {
        if (CurrentDirection != Player.direction)
        {
            CurrentDirection = Player.direction;
            CurrentCamera.backgroundColor = ColorDic[CurrentDirection];
        }

        if (transform.CompareTag(CurrentDirection.ToString()))
        {
            CurrentCamera.backgroundColor = Color.white;
        }
    }
}
