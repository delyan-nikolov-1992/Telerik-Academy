using System;

class OddOrEven
{
    static void Main()
    {
        try
        {
            Console.Write("The number to be checked: ");
            int number = int.Parse(Console.ReadLine());

            if (number % 2 == 0)
                Console.WriteLine(number + " is even.");
            else
                Console.WriteLine(number + " is odd.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}