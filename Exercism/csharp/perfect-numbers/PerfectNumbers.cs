using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static IEnumerable<int> GetFactors(int number)
    {
        for (int i = 1; i < number; i++)
        {
            if (number % i == 0) yield return i;
        }
    }

    public static Classification Classify(int number)
    {
        if (number < 1) throw new ArgumentOutOfRangeException();

        switch (GetFactors(number).Sum())
        {
            case int sum when sum == number:
                return Classification.Perfect;
            case int sum when sum > number:
                return Classification.Abundant;
            default:
                return Classification.Deficient;
        }
    }
}
