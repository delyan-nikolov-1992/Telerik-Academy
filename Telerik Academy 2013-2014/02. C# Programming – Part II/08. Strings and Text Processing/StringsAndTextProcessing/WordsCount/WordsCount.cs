using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class WordsCount
{
    static void Main()
    {
        Console.WriteLine("Write the text:");
        string text = Console.ReadLine();

        Dictionary<string, int> dictionary = new Dictionary<string, int>();
        MatchCollection words = Regex.Matches(text, @"\b\w+\b");

        foreach (Match word in words)
        {
            if (dictionary.ContainsKey(word.ToString()))
            {
                dictionary[word.ToString()] += 1;
            }
            else
            {
                dictionary.Add(word.ToString(), 1);
            }
        }

        Console.WriteLine();

        foreach (var word in dictionary)
        {
            Console.WriteLine("{0} - {1}", word.Key, word.Value);
        }
    }
}