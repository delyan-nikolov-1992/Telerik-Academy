using System;
using System.Text.RegularExpressions;

class CountSubstring
{
    static void Main()
    {
        Console.Write("The string to be searched in: ");
        string input = Console.ReadLine().ToLower();
        Console.Write("The searched substring: ");
        string substring = Console.ReadLine().ToLower();

        int result = Regex.Matches(input, substring).Count;

        Console.WriteLine("The result is: {0}", result);
    }
}