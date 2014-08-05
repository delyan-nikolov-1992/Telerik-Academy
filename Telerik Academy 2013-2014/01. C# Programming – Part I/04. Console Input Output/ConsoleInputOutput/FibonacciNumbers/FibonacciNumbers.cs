using System;

class FibonacciNumbers
{
    static void Main()
    {
        decimal firstNumber = 0;
        decimal secondNumber = 1;
        decimal current;

        Console.WriteLine("0: " + firstNumber);
        Console.WriteLine("1: " + secondNumber);

        for (int i = 2; i < 100; i++)
        {
            current = firstNumber + secondNumber;
            firstNumber = secondNumber;
            secondNumber = current;

            Console.WriteLine(i + ": " + current);
        }
    }
}