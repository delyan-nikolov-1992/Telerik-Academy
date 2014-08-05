using System;
using System.Text;
using System.Text.RegularExpressions;

class ReverseWords
{
    static void Main()
    {
        Console.WriteLine("The sentence to be reversed:");
        string sentence = Console.ReadLine();

        string wordsRegex = @"[^\s\.!?,;:]+";
        string separatorsRegex = @"[\s\.!?,;:]+";

        MatchCollection words = Regex.Matches(sentence, wordsRegex);
        MatchCollection separators = Regex.Matches(sentence, separatorsRegex);
        StringBuilder result = new StringBuilder();

        for (int i = 0; i < words.Count; i++)
        {
            result.Append(words[words.Count - 1 - i]);
            result.Append(separators[i]);
        }

        Console.WriteLine(result.ToString());
    }
}