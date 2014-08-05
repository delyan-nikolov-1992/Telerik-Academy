using System;
using System.Globalization;

class CountDays
{
    static void Main()
    {
        try
        {
            Console.Write("Enter the first date (dd.mm.yyyy): ");
            string firstInput = Console.ReadLine();
            Console.Write("Enter the second date (dd.mm.yyyy): ");
            string secondInput = Console.ReadLine();

            DateTime startDate = DateTime.ParseExact(firstInput, "d.MM.yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(secondInput, "d.MM.yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine("Days: {0}", (endDate - startDate).TotalDays);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid date! (dd.mm.yyyy)");
        }
    }
}