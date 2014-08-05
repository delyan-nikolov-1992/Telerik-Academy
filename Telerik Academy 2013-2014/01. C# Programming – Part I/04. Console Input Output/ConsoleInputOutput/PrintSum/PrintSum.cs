using System;

class PrintSum
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

            int sum = firstNumber + secondNumber + thirdNumber;

            Console.WriteLine("The sum is " + sum);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}