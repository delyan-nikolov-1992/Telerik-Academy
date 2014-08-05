using System;

class GreaterInteger
{
    static void Main()
    {
        try
        {
            Console.Write("The first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("The second number: ");
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber;

            if (firstNumber > secondNumber)
            {
                thirdNumber = firstNumber;
                firstNumber = secondNumber;
                secondNumber = thirdNumber;
            }

            Console.WriteLine("The first number is " + firstNumber);
            Console.WriteLine("The second number is " + secondNumber);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}