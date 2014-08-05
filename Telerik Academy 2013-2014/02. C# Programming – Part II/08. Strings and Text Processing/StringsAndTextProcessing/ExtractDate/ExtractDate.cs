using System;
using System.Globalization;
using System.Text.RegularExpressions;

class ExtractDate
{
    static void Main()
    {
        Console.WriteLine("Write the text:");
        string text = Console.ReadLine();

        string regex = @"\b\d{2}.\d{2}.\d{4}\b";
        MatchCollection dates = Regex.Matches(text, regex);
        var provider = new CultureInfo("en-CA", false);

        Console.WriteLine();

        foreach (Match item in dates)
        {
            DateTime date;

            if (DateTime.TryParse(item.ToString(), out date))
            {
                Console.WriteLine(date.ToString("dd/MM/yyyy", provider));
            }
        }
    }
}