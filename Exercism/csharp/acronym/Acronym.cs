using System;
using System.Linq;

public static class Acronym
{
    public static string Abbreviate(string phrase) => phrase.Split(new char[] { ' ', '-', '_' }, StringSplitOptions.RemoveEmptyEntries)
                                                            .Select(word => word.Trim().ToUpper()[0])
                                                            .Aggregate("", (acronym, newLetter) => acronym + newLetter);
}