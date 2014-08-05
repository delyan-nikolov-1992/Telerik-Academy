using System;

class PrimeNumber
{
    static void Main()
    {
        try
        {
            Console.Write("The number to be checked: ");
            int number = int.Parse(Console.ReadLine());
            bool result = true;

            if (number >= 1 && number <= 100)
            {
                if (number != 1)
                {
                    for (int i = 2; i <= number / 2; i++)
                    {
                        if (number % i == 0)
                            result = false;
                    }
                }
                else
                    result = false;

                if (result)
                    Console.WriteLine(number + " is a prime number.");
                else
                    Console.WriteLine(number + " is not a prime number");
            }
            else
                Console.WriteLine("The intervall of the given integer number is [1, 100]");
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}