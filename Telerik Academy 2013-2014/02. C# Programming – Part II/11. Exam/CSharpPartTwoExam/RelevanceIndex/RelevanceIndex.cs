using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

class RelevanceIndex
{
    static void Main()
    {
        string word = Console.ReadLine();
        int size = int.Parse(Console.ReadLine());
        string[] text = new string[size];

        for (int i = 0; i < text.Length; i++)
        {
            StringBuilder yes = new StringBuilder();
            string[] current = Console.ReadLine().Split(new char[] { ' ', ',', '.', '(', ')', ';', '-', '!', '?' },
                StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < current.Length - 1; j++)
            {
                yes.Append(current[j]);
                yes.Append(' ');
            }

            yes.Append(current[current.Length - 1]);
            text[i] = yes.ToString();
        }

        SearchWord(text, word);
    }

    static void SearchWord(string[] text, string word)
    {
        string[] output = new string[text.Length];
        int[] positions = new int[text.Length];
        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        for (int i = 0; i < text.Length; i++)
        {
            //output[i] = Regex.Replace(text[i], @"\W+", " ");
            output[i] = Regex.Replace(text[i], word.ToLower(), word.ToUpper(), RegexOptions.IgnoreCase);
            positions[i] = Regex.Matches(text[i], word.ToLower(), RegexOptions.IgnoreCase).Count;
            dictionary.Add(output[i], positions[i]);
        }


        foreach (var item in dictionary.OrderByDescending(key => key.Value))
        {
            Console.WriteLine(item.Key.ToString());
        }
    }
}