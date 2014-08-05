using System;
using System.Collections.Generic;
using System.IO;

class ExtractXML
{
    static void Main()
    {
        try
        {
            Console.WriteLine("The file location: ");
            string fileLocation = Console.ReadLine();
            StreamReader reader = new StreamReader(fileLocation);
            List<string> result = new List<string>();

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (i < line.Length - 1 && line[i] == '>' && line[i + 1] != '<')
                        {
                            int startingIndex = i + 1;
                            int wordLength = 0;

                            while (line[i] != '<')
                            {
                                wordLength++;
                                i++;
                            }

                            result.Add(line.Substring(startingIndex, wordLength - 1));
                        }
                    }

                    line = reader.ReadLine();
                }
            }

            Console.WriteLine();

            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine("{0}: {1}", i + 1, result[i]);
            }
        }
        catch
        {
            Console.WriteLine("Fatal error occurred.");
        }
    }
}