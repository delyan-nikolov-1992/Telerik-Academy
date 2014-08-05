using System;

class Factorial
{
    static void Main()
    {
        try
        {
            Console.Write("N = ");
            int firstNumber = int.Parse(Console.ReadLine());

            if (firstNumber > 2)
            {
                Console.Write("K = ");
                int secondNumber = int.Parse(Console.ReadLine());

                if (secondNumber > 1 && secondNumber < firstNumber)
                {
                    int result = 1;

                    for (int i = secondNumber + 1; i <= firstNumber; i++)
                    {
                        result *= i;
                    }

                    Console.WriteLine(firstNumber + "! / " + secondNumber + "! = " + result);
                }
                else
                {
                    Console.WriteLine("K must be greater than 1 and less than N.");
                }
            }
            else
            {
                Console.WriteLine("N must be greater than 2.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}