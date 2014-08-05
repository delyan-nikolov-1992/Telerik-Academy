using System;
using System.IO;

class InsertLineNumbers
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
                    int lineNumber = 1;
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        writer.WriteLine("{0}. {1}", lineNumber, line);

                        lineNumber++;
                        line = reader.ReadLine();
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