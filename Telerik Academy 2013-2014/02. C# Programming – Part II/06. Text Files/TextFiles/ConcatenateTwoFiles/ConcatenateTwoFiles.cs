using System;
using System.IO;

class ConcatenateTwoFiles
{
    static void Main()
    {
        try
        {
            // reading the first file
            Console.WriteLine("The first input file location: ");
            string fileLocation = Console.ReadLine();
            string firstText = FileContents(fileLocation);

            // reading the second file
            Console.WriteLine("The second input file location: ");
            fileLocation = Console.ReadLine();
            string secondText = FileContents(fileLocation);

            // writing the contents of the two files in a new file
            Console.WriteLine("The output file location: ");
            fileLocation = Console.ReadLine();
            StreamWriter writer = new StreamWriter(fileLocation);

            using (writer)
            {
                writer.WriteLine(firstText);
                writer.Write(secondText);
            }

            Console.WriteLine("\nDone!");
        }
        catch
        {
            Console.WriteLine("Fatal error occurred.");
        }
    }

    static string FileContents(string fileLocation)
    {
        string contents = "";
        StreamReader reader = new StreamReader(fileLocation);

        using (reader)
        {
            contents = reader.ReadToEnd();
        }

        return contents;
    }
}