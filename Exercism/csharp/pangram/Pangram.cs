using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        return "abcdefghijklmnopqrstuvwxyz".All(input.ToLower().Contains);
    }
}
