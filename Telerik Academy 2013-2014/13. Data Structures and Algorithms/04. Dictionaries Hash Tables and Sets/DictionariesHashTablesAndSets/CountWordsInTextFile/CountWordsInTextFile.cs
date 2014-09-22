namespace CountWordsInTextFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CountWordsInTextFile
    {
        public static void Main()
        {
            try
            {
                using (StreamReader reader = new StreamReader(".../.../words.txt"))
                {
                    string text = reader.ReadToEnd();
                    string[] words = GetWords(text);
                    IDictionary<string, int> wordsOccurrence = new Dictionary<string, int>();

                    foreach (string word in words)
                    {
                        int counter = 1;

                        if (wordsOccurrence.ContainsKey(word))
                        {
                            counter = wordsOccurrence[word] + 1;
                        }

                        wordsOccurrence[word] = counter;
                    }

                    var sortedWordsByOccurrence = wordsOccurrence.OrderBy(oc => oc.Value);

                    Console.WriteLine("The number of occurrences of each word:");

                    foreach (var pair in sortedWordsByOccurrence)
                    {
                        Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }
        }

        private static string[] GetWords(string text)
        {
            var matches = Regex.Matches(text, @"\b[\w']*\b");
            var words = matches.Cast<Match>().Select(m => m.Value.ToLower()).Where(v => !string.IsNullOrEmpty(v));

            return words.ToArray();
        }
    }
}