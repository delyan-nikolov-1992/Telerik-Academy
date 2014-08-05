using System;

class FormatOutput
{
    static void Main()
    {
        try
        {
            Console.Write("The input integer number: ");
            int input = int.Parse(Console.ReadLine());

            Console.WriteLine("{0,15}", input);
            Console.WriteLine("{0,15:X}", input);
            Console.WriteLine("{0,15:P}", input);
            Console.WriteLine("{0,15:E}", input);
        }
        catch (OverflowException)
        {
            Console.WriteLine("The number is not in the range of the type integer!");
        }
        catch (FormatException)
        {
            Console.WriteLine("The input must be an integer number!");
        }
    }
}