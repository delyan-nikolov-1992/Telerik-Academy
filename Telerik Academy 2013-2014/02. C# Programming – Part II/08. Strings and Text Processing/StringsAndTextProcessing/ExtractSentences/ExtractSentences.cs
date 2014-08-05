using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractSentences
{
    static void Main()
    {
        Console.WriteLine("The given text:");
        string text = Console.ReadLine();

        StringBuilder result = new StringBuilder();
        string[] sentences = text.Split('.');

        foreach (string current in sentences)
        {
            if (Regex.IsMatch(current, @"\bin\b"))
            {
                result.Append(current.Trim() + ".\n");
            }
        }

        Console.WriteLine(result.ToString());
    }
}