using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;

class OccurrencesOfWords
{
    static void Main()
    {
        try
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            StreamReader reader = new StreamReader("test.txt");
            StreamWriter writer = new StreamWriter("result.txt");
            string[] words = File.ReadAllLines("words.txt");

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        string regex = @"\b" + words[i] + @"\b";
                        MatchCollection matches = Regex.Matches(line, regex, RegexOptions.IgnoreCase);

                        if (dictionary.ContainsKey(words[i]))
                        {
                            dictionary[words[i]] += matches.Count;
                        }
                        else
                        {
                            dictionary.Add(words[i], matches.Count);
                        }
                    }

                    line = reader.ReadLine();
                }
            }

            using (writer)
            {
                foreach (var wordCount in dictionary.OrderByDescending(key => key.Value))
                {
                    writer.WriteLine("{0} - {1}", wordCount.Key, wordCount.Value);
                }
            }

            Console.WriteLine("Done!");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory not found!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found!");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Please enter valid file path!");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Please enter valid file path!");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("The file path must not be longer than 248 characters!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("File access error!");
        }
        catch (SecurityException)
        {
            Console.WriteLine("You don't have permission to access this file!");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Invalid path!");
        }
        catch (IOException)
        {
            Console.WriteLine("Input/Output error!");
        }
    }
}