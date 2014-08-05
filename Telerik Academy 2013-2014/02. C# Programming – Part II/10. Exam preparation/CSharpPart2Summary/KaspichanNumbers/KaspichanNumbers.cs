// 1. Kaspichan Numbers from C# Part 2 - 2012/2013 @ 4 Feb 2013 - Morning

using System;
using System.Text;
using System.Numerics;

class KaspichanNumbers
{
    static void Main()
    {
        BigInteger number = BigInteger.Parse(Console.ReadLine());
        StringBuilder kaspichanNumber = new StringBuilder();
        int counter = -1;
        BigInteger checkExp = number;

        do
        {
            checkExp /= 256;
            counter++;
        } while (checkExp > 0);


        while (counter > -1)
        {
            BigInteger exponent = (BigInteger)(Math.Pow(256, counter));
            BigInteger digit = (BigInteger)(number / exponent);
            number -= (BigInteger)(digit * exponent);

            if (digit > 25)
            {
                int firstLetter = (int)(digit / 26);
                int secondLetter = (int)(digit % 26);
                kaspichanNumber.Append((char)(firstLetter + 96));
                kaspichanNumber.Append((char)(secondLetter + 65));
            }
            else
            {
                char current = (char)(digit + 65);
                kaspichanNumber.Append(current);
            }

            counter--;
        }

        Console.WriteLine(kaspichanNumber.ToString());
    }
}