using System;
using System.Numerics;

class StrangeLandNumbers
{
    static void Main()
    {
        string strangeNumber = Console.ReadLine();
        BigInteger number = 0;
        double exp = 0;

        for (int i = strangeNumber.Length - 1; i >= 0; i--)
        {
            switch (strangeNumber[i])
            {
                case 'f':
                    number += (BigInteger)(Math.Pow(7, exp) * 0);
                    break;
                case 'N':
                    if (i - 2 >= 0 && strangeNumber[i - 1].Equals('I') && strangeNumber[i - 2].Equals('b'))
                    {
                        number += (BigInteger)(Math.Pow(7, exp) * 1);
                        i -= 2;
                    }
                    break;
                case 'C':
                    if (i - 4 >= 0 && strangeNumber[i - 1].Equals('E') && strangeNumber[i - 2].Equals('J')
                        && strangeNumber[i - 3].Equals('B') && strangeNumber[i - 4].Equals('o'))
                    {
                        number += (BigInteger)(Math.Pow(7, exp) * 2);
                        i -= 4;
                    }
                    break;
                case 'L':
                    if (i - 6 >= 0 && strangeNumber[i - 1].Equals('V') && strangeNumber[i - 2].Equals('A')
                        && strangeNumber[i - 3].Equals('R') && strangeNumber[i - 4].Equals('T')
                        && strangeNumber[i - 5].Equals('N') && strangeNumber[i - 6].Equals('m'))
                    {
                        number += (BigInteger)(Math.Pow(7, exp) * 3);
                        i -= 6;
                    }
                    break;
                case 'Q':
                    if (i - 5 >= 0 && strangeNumber[i - 1].Equals('N') && strangeNumber[i - 2].Equals('K')
                        && strangeNumber[i - 3].Equals('V') && strangeNumber[i - 4].Equals('P')
                        && strangeNumber[i - 5].Equals('l'))
                    {
                        number += (BigInteger)(Math.Pow(7, exp) * 4);
                        i -= 5;
                    }
                    break;
                case 'E':
                    if (i - 3 >= 0 && strangeNumber[i - 1].Equals('W') && strangeNumber[i - 2].Equals('N')
                        && strangeNumber[i - 3].Equals('p'))
                    {
                        number += (BigInteger)(Math.Pow(7, exp) * 5);
                        i -= 3;
                    }
                    break;
                case 'T':
                    if (i - 1 >= 0 && strangeNumber[i - 1].Equals('h'))
                    {
                        number += (BigInteger)(Math.Pow(7, exp) * 6);
                        i -= 1;
                    }
                    break;
                default:
                    break;
            }

            exp++;
        }

        Console.WriteLine(number);
    }
}