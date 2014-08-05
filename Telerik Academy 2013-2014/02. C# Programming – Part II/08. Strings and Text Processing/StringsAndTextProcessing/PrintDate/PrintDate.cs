using System;
using System.Globalization;

class PrintDate
{
    static void Main()
    {
        try
        {
            Console.Write("Enter the date (dd.mm.yyyy hh:mm:ss): ");
            string input = Console.ReadLine();

            DateTime date = DateTime.ParseExact(input, "d.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            date = date.AddHours(6.5);

            Console.WriteLine("{0:d.MM.yyyy HH:mm:ss} {1}", date, date.ToString("dddd", new CultureInfo("bg-BG")));
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid date! (dd.mm.yyyy hh:mm:ss)");
        }
    }
}