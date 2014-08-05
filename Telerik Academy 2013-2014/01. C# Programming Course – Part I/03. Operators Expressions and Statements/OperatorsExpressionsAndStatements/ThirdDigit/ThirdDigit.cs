using System;

class ThirdDigit
{
    static void Main()
    {
        try
        {
            Console.Write("The number to be checked: ");
            int number = int.Parse(Console.ReadLine());
            int digit;
            bool result;

            number /= 100;
            digit = number % 10;

            if (digit == 7)
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