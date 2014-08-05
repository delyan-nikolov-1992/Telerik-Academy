using System;

class Division
{
    static void Main()
    {
        try
        {
            Console.Write("The number to be checked: ");
            int number = int.Parse(Console.ReadLine());
            bool result;

            if ((number % 7 == 0) && (number % 5 == 0))
                result = true;
            else
                result = false;

            Console.WriteLine(result);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}