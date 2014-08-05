using System;

class GreatestCommonDivisor
{
    static void Main()
    {
        try
        {
            Console.Write("The first number is: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("The second number is: ");
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber;

            if (firstNumber != 0 || secondNumber != 0)
            {
                while (secondNumber != 0)
                {
                    thirdNumber = secondNumber;
                    secondNumber = firstNumber % secondNumber;
                    firstNumber = thirdNumber;
                }

                Console.WriteLine(firstNumber);
            }
            else
            {
                Console.WriteLine("At least one of the numbers must not be 0.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}