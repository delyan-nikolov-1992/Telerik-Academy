using System;
using System.Collections.Generic;

class AddNumbers
{
    static void Main()
    {
        try
        {
            Console.Write("The size of the first array: ");
            int firstSize = int.Parse(Console.ReadLine());
            Console.Write("The size of the second array: ");
            int secondSize = int.Parse(Console.ReadLine());

            if (firstSize >= 0 && secondSize >= 0 && firstSize <= 10000 && secondSize < 10000)
            {
                byte[] firstNumber = new byte[firstSize];

                for (int i = 0; i < firstSize; i++)
                {
                    Console.Write("firstNumber[{0}] = ", i);
                    firstNumber[i] = byte.Parse(Console.ReadLine());

                    if (firstNumber[i] > 9)
                    {
                        Console.WriteLine("The digits must be between 0 and 9.");
                        return;
                    }
                }

                byte[] secondNumber = new byte[secondSize];

                for (int i = 0; i < secondSize; i++)
                {
                    Console.Write("secondNumber[{0}] = ", i);
                    secondNumber[i] = byte.Parse(Console.ReadLine());

                    if (secondNumber[i] > 9)
                    {
                        Console.WriteLine("The digits must be between 0 and 9.");
                        return;
                    }
                }

                if (firstNumber.Length == 0 && secondNumber.Length == 0)
                {
                    Console.WriteLine("There are no numbers to be added.");
                }
                else
                {
                    AddDigits(firstNumber, secondNumber);
                }
            }
            else
            {
                Console.WriteLine("The size of the arrays must be in the range [0;10 000].");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static void AddDigits(byte[] firstNumber, byte[] secondNumber)
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

        Console.WriteLine("The number backwards as it is in the array:");

        //prints the number backwards, because the task says: "the last digit is kept in arr[0]"
        foreach (byte currentDigit in result)
        {
            Console.Write(currentDigit);
        }

        Console.WriteLine();
        Console.WriteLine("The real reversed representation of the number:");

        //reverses the number to get the real representation of the number
        result.Reverse();

        //prints the exact number
        foreach (byte currentDigit in result)
        {
            Console.Write(currentDigit);
        }

        Console.WriteLine();
    }
}