using System;
using System.Collections.Generic;

class LettersCount
{
    static void Main()
    {
        Console.WriteLine("Write the text:");
        string text = Console.ReadLine();

        Dictionary<char, int> dictionary = new Dictionary<char, int>();

        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsLetter(text[i]))
            {
                if (dictionary.ContainsKey(text[i]))
                {
                    dictionary[text[i]]++;
                }
                else
                {
                    dictionary.Add(text[i], 1);
                }
            }
        }

        Console.WriteLine();

        foreach (var letter in dictionary)
        {
            Console.WriteLine("{0} - {1}", letter.Key, letter.Value);
        }
    }
}