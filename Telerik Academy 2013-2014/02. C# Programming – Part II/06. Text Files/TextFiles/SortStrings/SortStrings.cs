using System;
using System.Collections.Generic;
using System.IO;

class SortStrings
{
    static void Main()
    {
        try
        {
            Console.WriteLine("The input file location: ");
            string fileLocation = Console.ReadLine();
            StreamReader reader = new StreamReader(fileLocation);

            Console.WriteLine("The output file location: ");
            fileLocation = Console.ReadLine();
            StreamWriter writer = new StreamWriter(fileLocation);

            using (reader)
            {
                using (writer)
                {
                    string line = reader.ReadLine();
                    List<string> contents = new List<string>();

                    while (line != null)
                    {
                        contents.Add(line);
                        line = reader.ReadLine();
                    }

                    contents.Sort();

                    foreach (string currentLine in contents)
                    {
                        writer.WriteLine(currentLine);
                    }
                }
            }

            Console.WriteLine("\nDone!");
        }
        catch
        {
            Console.WriteLine("Fatal error occurred.");
        }
    }
}