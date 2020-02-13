using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Important static class that holds all the color for game objects
 */
public static class ColorHolder
{
    private static Color PlayerColorGround = new Color(204 / 256f, 164 / 256f, 59 / 256f, 1);
    private static Color PlayerColorLeft = new Color(59 / 256f, 53 / 256f, 97 / 256f, 1);
    private static Color PlayerColorRight = new Color(7 / 256f, 79 / 256f, 87 / 256f, 1);
    private static Color PlayerColorCeiling = new Color(0, 0, 0, 1);

    private static Color BackgroundColorGround = new Color(228 / 256f, 179 / 256f, 99 / 256f, 1);
    private static Color BackgroundColorLeft = new Color(37 / 256f, 89 / 256f, 87 / 256f, 1);
    private static Color BackgroundColorRight = new Color(121 / 256f, 123 / 256f, 132 / 256f, 1);
    private static Color BackgroundColorCeiling = new Color(230 / 256f, 230 / 256f, 233 / 256f, 1);

    private static Color PlatformColorGround = new Color(239 / 256f, 100 / 256f, 97 / 256f, 1);
    private static Color PlatformColorLeft = new Color(67 / 256f, 124 / 256f, 144 / 256f, 1);
    private static Color PlatformColorRight = new Color(237 / 256f, 187 / 256f, 180 / 256f, 1);
    private static Color PlatformColorCeiling = new Color(0, 0, 0, 1);

    public static Dictionary<char, Color> PlayerColor = new Dictionary<char, Color> {
        { 'g', PlayerColorGround },
        { 'l', PlayerColorLeft },
        { 'r', PlayerColorRight },
        { 'c', PlayerColorCeiling }
    };
    public static Dictionary<char, Color> BackgroundColor = new Dictionary<char, Color> {
        { 'g', BackgroundColorGround },
        { 'l', BackgroundColorLeft },
        { 'r', BackgroundColorRight },
        { 'c', BackgroundColorCeiling }
    };
    public static Dictionary<char, Color> PlatformColor = new Dictionary<char, Color> {
        { 'g', PlatformColorGround },
        { 'l', PlatformColorLeft },
        { 'r', PlatformColorRight },
        { 'c', PlatformColorCeiling }
    };
}
