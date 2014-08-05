using System;

class FactorialsMultiplication
{
    static void Main()
    {
        try
        {
            Console.Write("N = ");
            int firstNumber = int.Parse(Console.ReadLine());

            if (firstNumber > 1)
            {
                Console.Write("K = ");
                int secondNumber = int.Parse(Console.ReadLine());

                if (secondNumber > firstNumber)
                {
                    int difference = secondNumber - firstNumber;
                    int result = 1;

                    for (int i = 2; i <= firstNumber; i++)
                    {
                        result *= i;
                    }

                    result *= result;

                    for (int i = firstNumber + 1; i <= secondNumber; i++)
                    {
                        result *= i;
                    }

                    for (int i = 2; i <= difference; i++)
                    {
                        result /= i;
                    }

                    Console.WriteLine(firstNumber + "! * " + secondNumber + "! / " + difference + "! = " + result);
                }
                else
                {
                    Console.WriteLine("K must be greater than N.");
                }
            }
            else
            {
                Console.WriteLine("N must be greater than 1.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}