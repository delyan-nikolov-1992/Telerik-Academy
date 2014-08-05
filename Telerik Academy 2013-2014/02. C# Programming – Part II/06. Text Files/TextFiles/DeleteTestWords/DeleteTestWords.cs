using System;
using System.IO;
using System.Text.RegularExpressions;

class DeleteTestWords
{
    static void Main()
    {
        try
        {
            Console.WriteLine("The file location: ");
            string fileLocation = Console.ReadLine();
            string contents = File.ReadAllText(fileLocation);
            File.WriteAllText(fileLocation, Regex.Replace(contents, @"\b(test\w*)\b", ""));
            Console.WriteLine("\nDone!");
        }
        catch
        {
            Console.WriteLine("Fatal error occurred.");
        }
    }
}