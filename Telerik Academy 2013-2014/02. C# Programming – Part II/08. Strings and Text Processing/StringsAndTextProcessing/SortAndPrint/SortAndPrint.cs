using System;

class SortAndPrint
{
    static void Main()
    {
        Console.WriteLine("Write the words, separated by spaces:");
        string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Array.Sort(words);

        foreach (string current in words)
        {
            Console.WriteLine(current);
        }
    }
}