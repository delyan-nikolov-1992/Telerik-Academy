namespace CountWordsInText
{
    using System;
    using System.Diagnostics;

    public class TestTrie
    {
        public const int WordsToAdd = 1000000;
        public const int WordsToSearch = 1000000;

        private static Random rnd = new Random();

        public static void Main()
        {
            var sw = new Stopwatch();

            var trie = new Trie();

            for (int i = 0; i < WordsToAdd; i++)
            {
                string word = GetRandomWord();
                sw.Start();
                trie.Add(word);
                sw.Stop();
            }

            Console.WriteLine("Added {0} words for {1} time", WordsToAdd, sw.Elapsed);

            sw.Reset();
            for (int i = 0; i < WordsToSearch; i++)
            {
                string word = GetRandomWord();
                sw.Start();
                trie.GetWordOccurance(word);
                sw.Stop();
            }

            Console.WriteLine("Found {0} words for {1} time", WordsToSearch, sw.Elapsed);

            Console.Write("Most common word: ");
            Console.WriteLine(trie.GetMostCommonWord());
        }

        public static string GetRandomWord()
        {
            char[] newWord = new char[rnd.Next(5, 12)];

            for (int i = 0; i < newWord.Length; i++)
            {
                newWord[i] = (char)rnd.Next(65, 91);
            }

            return new string(newWord);
        }
    }
}