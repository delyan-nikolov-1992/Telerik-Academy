using System;
using System.IO;

class ReplaceSubstrings
{
    static void Main()
    {
        try
        {
            Console.WriteLine("The file location: ");
            string fileLocation = Console.ReadLine();
            string contents = File.ReadAllText(fileLocation);
            File.WriteAllText(fileLocation, contents.Replace("start", "finish"));
            Console.WriteLine("\nDone!");
        }
        catch
        {
            Console.WriteLine("Fatal error occurred.");
        }
    }
}