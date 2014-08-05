using System;
using System.Collections.Generic;

class GivenBaseToOtherBase
{
    static void Main()
    {
        try
        {
            Console.Write("s = ");
            byte firstBase = byte.Parse(Console.ReadLine());
            Console.Write("d = ");
            byte secondBase = byte.Parse(Console.ReadLine());

            if (firstBase >= 2 && firstBase <= 16 && secondBase >= 2 && secondBase <= 16)
            {
                Console.Write("Enter the number: ");
                string value = Console.ReadLine();

                int decimalNumber = NumberToDecimal(firstBase, value);
                PrintFinalNumber(DecimalToY(secondBase, decimalNumber));
            }
            else
            {
                Console.WriteLine("s and d must be in the range [2;16].");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static int NumberToDecimal(int firstBase, string value)
    {
        byte[] convertedValue = new byte[value.Length];

        for (int i = 0; i < convertedValue.Length; i++)
        {
            switch (value[i])
            {
                case 'A':
                    convertedValue[i] = 10;
                    break;
                case 'B':
                    convertedValue[i] = 11;
                    break;
                case 'C':
                    convertedValue[i] = 12;
                    break;
                case 'D':
                    convertedValue[i] = 13;
                    break;
                case 'E':
                    convertedValue[i] = 14;
                    break;
                case 'F':
                    convertedValue[i] = 15;
                    break;
                default:
                    convertedValue[i] = byte.Parse(Convert.ToString(value[i]));
                    break;
            }
        }

        int decValue = 0;

        for (int i = 0, j = convertedValue.Length - 1; i < convertedValue.Length; i++, j--)
        {
            decValue += convertedValue[i] * (int)Math.Pow(firstBase, j);
        }

        return decValue;
    }

    static List<byte> DecimalToY(int secondBase, int decNumber)
    {
        List<byte> finalNumber = new List<byte>();

        while (decNumber != 0)
        {
            finalNumber.Add((byte)(decNumber % secondBase));
            decNumber /= secondBase;
        }

        return finalNumber;
    }

    static void PrintFinalNumber(List<byte> finalNumber)
    {
        for (int i = finalNumber.Count - 1; i >= 0; i--)
        {
            switch (finalNumber[i])
            {
                case 10:
                    Console.Write('A');
                    break;
                case 11:
                    Console.Write('B');
                    break;
                case 12:
                    Console.Write('C');
                    break;
                case 13:
                    Console.Write('D');
                    break;
                case 14:
                    Console.Write('E');
                    break;
                case 15:
                    Console.Write('F');
                    break;
                default:
                    Console.Write(finalNumber[i]);
                    break;
            }
        }

        Console.WriteLine();
    }
}