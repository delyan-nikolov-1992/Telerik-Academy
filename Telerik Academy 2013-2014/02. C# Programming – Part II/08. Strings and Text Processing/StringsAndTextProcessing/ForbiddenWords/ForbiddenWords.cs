using System;
using System.Text.RegularExpressions;

class ForbiddenWords
{
    static void Main()
    {
        Console.WriteLine("The given text:");
        string text = Console.ReadLine();
        Console.Write("Words: ");
        string[] words = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        string regex = @"\b(" + String.Join("|", words) + @")\b";
        string result = Regex.Replace(text, regex, m => new String('*', m.Length));

        Console.WriteLine(result);
    }
}