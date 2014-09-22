namespace ExtractElements
{
    using System;
    using System.Collections.Generic;

    public class ExtractElements
    {
        public static void Main()
        {
            string[] words = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            IDictionary<string, int> wordsOccurrence = new Dictionary<string, int>();
            ICollection<string> extractedWords = new HashSet<string>();

            foreach (string word in words)
            {
                int counter = 1;

                if (wordsOccurrence.ContainsKey(word))
                {
                    counter = wordsOccurrence[word] + 1;
                }

                wordsOccurrence[word] = counter;
            }

            foreach (var pair in wordsOccurrence)
            {
                if (pair.Value % 2 != 0)
                {
                    extractedWords.Add(pair.Key);
                }
            }

            Console.WriteLine("All elements that present in the sequence odd number of times:");

            foreach (var word in extractedWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}