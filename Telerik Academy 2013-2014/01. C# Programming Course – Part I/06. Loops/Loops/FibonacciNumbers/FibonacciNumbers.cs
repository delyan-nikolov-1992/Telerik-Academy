using System;

class FibonacciNumbers
{
    static void Main()
    {
        try
        {
            Console.Write("N = ");
            int numbers = int.Parse(Console.ReadLine());

            if (numbers > 0)
            {
                decimal firstNumber = 0;
                decimal secondNumber = 1;
                decimal current;
                decimal result = 0;

                if (numbers != 1)
                {
                    result += 1;
                }

                for (int i = 2; i < numbers; i++)
                {
                    current = firstNumber + secondNumber;
                    firstNumber = secondNumber;
                    secondNumber = current;
                    result += current;
                }

                Console.WriteLine("The sum is " + result);
            }
            else
            {
                Console.WriteLine("N must be positive.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}