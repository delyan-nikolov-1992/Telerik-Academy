using System;
using System.Text.RegularExpressions;

class ChangeToUpper
{
    static void Main()
    {
        Console.Write("The string to be changed: ");
        string input = Console.ReadLine();

        string output = Regex.Replace(input, @"<upcase>([\w\s]*)</upcase>", match => match.Groups[1].Value.ToUpper());

        Console.WriteLine(output);
    }
}