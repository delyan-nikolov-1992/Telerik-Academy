using System;

class TheBiggestInteger
{
    static void Main()
    {
        try
        {
            Console.Write("The first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("The second number: ");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.Write("The third number: ");
            int thirdNumber = int.Parse(Console.ReadLine());

            if (firstNumber >= secondNumber && firstNumber >= thirdNumber)
            {
                Console.WriteLine("The biggest integer is " + firstNumber);
            }
            else if (secondNumber >= firstNumber && secondNumber >= thirdNumber)
            {
                Console.WriteLine("The biggest integer is " + secondNumber);
            }
            else
            {
                Console.WriteLine("The biggest integer is " + thirdNumber);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}