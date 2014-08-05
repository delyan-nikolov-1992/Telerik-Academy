using System;

class GreaterNumber
{
    static void Main()
    {
        try
        {
            Console.Write("The first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("The second number: ");
            int secondNumber = int.Parse(Console.ReadLine());

            int greaterNumber = Math.Max(firstNumber, secondNumber);

            Console.WriteLine("The greater number is " + greaterNumber);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}