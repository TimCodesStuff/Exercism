using System;
using System.Collections.Generic;
using System.Linq;

public class PhoneNumber
{
    public static bool IsTenDigitNumberFormattedCorrectly(IEnumerable<char> tenDigitNumber) => 
            tenDigitNumber.First() == '0'
            || tenDigitNumber.First() == '1'
            || tenDigitNumber.ElementAt(3) == '0'
            || tenDigitNumber.ElementAt(3) == '1'
            ? false : true;


    public static string Clean(string phoneNumber)
    {
        // Remove all non-digit characters
        IEnumerable<char> filteredNumber = phoneNumber.Where(char.IsDigit);

        // Ensure 11 digit numbers begin with a '1'
        if (filteredNumber.Count() == 11)
        {
            if (filteredNumber.First() != '1') { throw new ArgumentException(); }
            filteredNumber = filteredNumber.Skip(1);
        }

        // Ensure final number is 10 digits long and is formatted properly
        if (filteredNumber.Count() != 10 || !IsTenDigitNumberFormattedCorrectly(filteredNumber)) { throw new ArgumentException(); }

        return string.Concat(filteredNumber);
    }
}