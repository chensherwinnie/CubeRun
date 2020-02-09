using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuColor : MonoBehaviour
{
    private Dictionary<char, Color> TextColor;
    private Dictionary<char, Color> BackgroundColor;
    private Dictionary<char, Color> ButtonColor;

    private Color PlayerColorGround;
    private Color PlayerColorLeft;
    private Color PlayerColorRight;
    private Color PlayerColorCeiling;

    private Color PlatformColorGround;
    private Color PlatformColorLeft;
    private Color PlatformColorRight;
    private Color PlatformColorCeiling;

    private Color BackgroundColorGround;
    private Color BackgroundColorLeft;
    private Color BackgroundColorRight;
    private Color BackgroundColorCeiling;


    void Start()
    {
        PlayerColorGround = new Color(204 / 256f, 164 / 256f, 59 / 256f, 1);
        PlayerColorLeft = new Color(59 / 256f, 53 / 256f, 97 / 256f, 1);
        PlayerColorRight = new Color(7 / 256f, 79 / 256f, 87 / 256f, 1);
        PlayerColorCeiling = new Color(0, 0, 0, 1);

        BackgroundColorGround = new Color(228 / 256f, 179 / 256f, 99 / 256f, 1);
        BackgroundColorLeft = new Color(37 / 256f, 89 / 256f, 87 / 256f, 1);
        BackgroundColorRight = new Color(121 / 256f, 123 / 256f, 132 / 256f, 1);
        BackgroundColorCeiling = new Color(230 / 256f, 230 / 256f, 233 / 256f, 1);

        PlatformColorGround = new Color(239 / 256f, 100 / 256f, 97 / 256f, 1);
        PlatformColorLeft = new Color(67 / 256f, 124 / 256f, 144 / 256f, 1);
        PlatformColorRight = new Color(237 / 256f, 187 / 256f, 180 / 256f, 1);
        PlatformColorCeiling = new Color(0, 0, 0, 1);

        TextColor = new Dictionary<char, Color>();
        BackgroundColor = new Dictionary<char, Color>();
        ButtonColor = new Dictionary<char, Color>();

        TextColor.Add('g', PlayerColorLeft);
        TextColor.Add('l', PlayerColorGround);
        TextColor.Add('r', PlayerColorRight);
        TextColor.Add('c', PlayerColorCeiling);

        BackgroundColor.Add('g', BackgroundColorGround);
        BackgroundColor.Add('l', BackgroundColorLeft);
        BackgroundColor.Add('r', BackgroundColorRight);
        BackgroundColor.Add('c', BackgroundColorCeiling);

        ButtonColor.Add('g', PlatformColorGround);
        ButtonColor.Add('l', PlatformColorLeft);
        ButtonColor.Add('r', PlatformColorRight);
        ButtonColor.Add('c', PlatformColorCeiling);
    }
}
