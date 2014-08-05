using System;
using System.Collections.Generic;

class Factorial
{
    static void Main()
    {
        try
        {
            Console.Write("n = ");
            int number = int.Parse(Console.ReadLine());

            if (number >= 1 && number <= 100)
            {
                byte[] factorial = { 1 };

                for (int i = 1; i <= number; i++)
                {
                    factorial = Multiply(factorial, i);
                }

                for (int i = factorial.Length - 1; i >= 0; i--)
                {
                    Console.Write(factorial[i]); // Reversed
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("n must be in the range [1;100].");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static byte[] Multiply(byte[] digits, int number)
    {
        byte[] result = { 0 };

        for (int i = 0; i < number; i++)
        {
            result = AddDigits(result, digits);
        }

        return result;
    }

    static byte[] AddDigits(byte[] firstNumber, byte[] secondNumber)
    {
        List<byte> result = new List<byte>();
        byte carryOne = 0;
        byte current;
        byte[] biggerNumber;
        byte[] smallerNumber;

        if (firstNumber.Length >= secondNumber.Length)
        {
            biggerNumber = (byte[])firstNumber.Clone();
            smallerNumber = (byte[])secondNumber.Clone();
        }
        else
        {
            biggerNumber = (byte[])secondNumber.Clone();
            smallerNumber = (byte[])firstNumber.Clone();
        }

        for (int i = 0; i < smallerNumber.Length; i++)
        {
            current = (byte)(biggerNumber[i] + smallerNumber[i] + carryOne);
            carryOne = 0;

            if (current > 9)
            {
                current %= 10;
                carryOne = 1;
            }

            result.Add(current);
        }

        for (int i = smallerNumber.Length; i < biggerNumber.Length; i++)
        {
            current = (byte)(biggerNumber[i] + carryOne);
            carryOne = 0;

            if (current > 9)
            {
                current %= 10;
                carryOne = 1;
            }

            result.Add(current);
        }

        if (carryOne == 1)
        {
            result.Add(carryOne);
        }

        return result.ToArray();
    }
}