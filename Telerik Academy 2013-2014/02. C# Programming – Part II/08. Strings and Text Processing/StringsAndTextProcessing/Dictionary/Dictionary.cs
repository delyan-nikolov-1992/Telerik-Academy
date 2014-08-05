using System;
using System.Collections.Generic;

class Dictionary
{
    static void Main()
    {
        Console.Write("The word to be translated: ");
        string word = Console.ReadLine();

        Dictionary<string, string> dictionary = new Dictionary<string, string>() { 
                                    {".NET", "platform for applications from Microsoft"}, 
                                    {"CLR", "managed execution environment for .NET"}, 
                                    {"namespace", "hierarchical organization of classes"} };

        if (dictionary.ContainsKey(word))
        {
            Console.WriteLine("{0} - {1}", word, dictionary[word]);
        }
        else
        {
            Console.WriteLine("There is no such word in this dictionary!");
        }
    }
}