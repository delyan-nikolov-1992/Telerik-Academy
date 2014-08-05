using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        Console.WriteLine("Write the text:");
        string text = Console.ReadLine();

        Console.WriteLine();

        // regex for a valid e-mail
        foreach (var item in Regex.Matches(text, @"[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]{2,4}"))
        {
            Console.WriteLine(item);
        }
    }
}