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
        ColorDic = ColorHolder.BackgroundColor;
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
