using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractPalindromes
{
    static void Main()
    {
        Console.WriteLine("Write the text:");
        string text = Console.ReadLine();

        string[] words = Regex.Replace(text, @"\W+", " ").Split(' ');
        StringBuilder palindrome = new StringBuilder();

        for (int i = 0; i < words.Length; i++)
        {
            for (int j = words[i].Length - 1; j >= 0; j--)
            {
                palindrome.Append(words[i][j]);
            }

            if (palindrome.ToString().Equals(words[i]))
            {
                Console.WriteLine(palindrome.ToString());
            }

            palindrome.Clear();
        }
    }
}