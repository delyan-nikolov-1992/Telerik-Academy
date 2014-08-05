// 1. Durankulak Numbers from C# Part 2 - 2012/2013 @ 5 Feb 2013

using System;

class DurankulakNumbers
{
    static void Main()
    {
        string durankulakNumber = Console.ReadLine();
        long number = 0;
        long current;
        long exp = 0;

        for (int i = durankulakNumber.Length - 1; i >= 0; i--)
        {
            current = durankulakNumber[i] - 65;

            if (i > 0 && durankulakNumber[i - 1] > 96)
            {
                current += (durankulakNumber[i - 1] - 96) * 26;
                i--;
            }

            number += (long)(Math.Pow(168, exp) * current);
            exp++;
        }

        Console.WriteLine(number);
    }
}