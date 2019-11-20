public static class Pangram
{
    public static bool IsPangram(string input)
    {
        foreach (char c in "abcdefghijklmnopqrstuvwxyz")
        {
            if (!input.ToLower().Contains(c))
            {
                return false;
            }
        }
        return true;
    }
}
