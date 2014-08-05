using System;

class DivisionWithFive
{
    static void Main()
    {
        try
        {
            Console.Write("The first number of the intervall: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("The second number of the intervall: ");
            int secondNumber = int.Parse(Console.ReadLine());

            if (firstNumber <= 0 || secondNumber <= 0)
            {
                Console.WriteLine("The two numbers must be positive.");
            }
            else if (firstNumber > secondNumber)
            {
                Console.WriteLine("The first number of the intervall must be less than or "
                                                + "equal to the second number");
            }
            else
            {
                int counter = 0;

                for (int i = firstNumber; i <= secondNumber; i++)
                {
                    if (i % 5 == 0)
                    {
                        counter++;
                    }
                }

                Console.WriteLine(counter);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}