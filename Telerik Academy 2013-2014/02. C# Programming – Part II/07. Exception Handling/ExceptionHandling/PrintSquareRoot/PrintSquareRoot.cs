using System;

class PrintSquareRoot
{
    static void Main()
    {
        try
        {
            Console.Write("Provide a positive integer number: ");
            uint number = uint.Parse(Console.ReadLine());

            Console.WriteLine("The square root of {0} is {1}", number, Math.Sqrt(number));
        }
        catch (OverflowException)
        {
            Console.WriteLine("Invalid number");
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number");
        }
        finally
        {
            Console.WriteLine("Good bye");
        }
    }
}