using System;
using System.IO;
using System.Text.RegularExpressions;

class ExtractTitelAndBodyText
{
    static void Main()
    {
        try
        {
            Console.WriteLine("The file location: ");
            string fileLocation = Console.ReadLine();

            string html = File.ReadAllText(fileLocation);
            string regex = "(?<=^|>)[^><]+?(?=<|$)";
            MatchCollection extracts = Regex.Matches(html, regex);

            foreach (var value in extracts)
            {
                Console.WriteLine(value);
            }
        }
        catch
        {
            Console.WriteLine("Error input!");
        }
    }
}