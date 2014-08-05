using System;
using System.IO;

class DeleteOddLines
{
    static void Main()
    {
        try
        {
            Console.WriteLine("The file location: ");
            string fileLocation = Console.ReadLine();
            string[] lines = File.ReadAllLines(fileLocation);
            StreamWriter writer = new StreamWriter(fileLocation);

            using (writer)
            {
                for (int i = 1; i < lines.Length; i += 2)
                {
                    writer.WriteLine(lines[i]);
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