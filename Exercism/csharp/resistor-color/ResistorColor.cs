using System;

public static class ResistorColor
{
    private static readonly string[] colors = new[] { "black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white" };

    public static int ColorCode(string color) => Array.FindIndex(colors, x => x == color);

    public static string[] Colors() => colors;
}