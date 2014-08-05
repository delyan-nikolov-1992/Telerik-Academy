using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("The year to be checked: ");
            int year = int.Parse(Console.ReadLine());

            //DateTime works only for years in the range [0; 9 999]
            if (year > 0 && year < 10000)
            {
                Console.WriteLine("Is {0} leap year: {1}", year, DateTime.IsLeapYear(year));
            }
            else
            {
                Console.WriteLine("The year must be a number in the range [0; 9 999].");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}