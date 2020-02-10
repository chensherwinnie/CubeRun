using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuColor : MonoBehaviour
{
    private Dictionary<char, Color> TextColor;
    private Dictionary<char, Color> BackgroundColor;
    private Dictionary<char, Color> ButtonColor;
    
    void Start()
    {
        TextColor = ColorHolder.PlayerColor;
        BackgroundColor = ColorHolder.BackgroundColor;
        ButtonColor = ColorHolder.PlatformColor;
    }
}
