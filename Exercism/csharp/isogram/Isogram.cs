using System;
using System.Collections.Generic;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        IEnumerable<char> lowercaseWord = word.ToLower().Where(char.IsLetter);
        return lowercaseWord.Count() == lowercaseWord.Distinct().Count();
    }
}
