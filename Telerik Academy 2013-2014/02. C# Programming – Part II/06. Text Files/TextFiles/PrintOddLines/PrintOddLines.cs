using System;
using System.IO;

class PrintOddLines
{
    static void Main()
    {
        try
        {
            Console.WriteLine("The file location: ");
            string fileLocation = Console.ReadLine();
            StreamReader reader = new StreamReader(fileLocation);

            using (reader)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                Console.WriteLine();

                while (line != null)
                {
                    lineNumber++;

                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine("Line {0}: {1}", lineNumber, line);
                    }

                    line = reader.ReadLine();
                }
            }
        }
        catch
        {
            Console.WriteLine("Fatal error occurred.");
        }
    }
}