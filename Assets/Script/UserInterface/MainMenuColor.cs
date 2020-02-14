using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuColor : MonoBehaviour
{
    private Dictionary<char, Color> CubeColor;
    private Dictionary<char, Color> BackgroundColor;
    private Dictionary<char, Color> TextColor;
    
    void Start()
    {
        CubeColor = new Dictionary<char, Color>
        { 
        };
        BackgroundColor = ColorHolder.BackgroundColor;
        CubeColor = ColorHolder.PlatformColor;
        TextColor = ColorHolder.PlayerColor;

        char[] AllColor = { 'g', 'l', 'r', 'c' };
        char ColorChar = AllColor[Random.Range(0, AllColor.Length)];
        Debug.Log(ColorChar);
        
        GameObject.Find("Camera").GetComponent<Camera>().backgroundColor = BackgroundColor['l'];
        GameObject.Find("Cube").GetComponent<Renderer>().material.color = CubeColor['l'];


    }
}
