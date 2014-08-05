using System;
using System.Text.RegularExpressions;

class URLAddress
{
    static void Main()
    {
        Console.WriteLine("The URL address:");
        string url = Console.ReadLine();
        string regex = @"(?<protocol>^(ht|f)tp(s?))\:\/\/(?<server>(?:www\.)?[a-zA-Z0-9\.]+\.[a-z]{2,4})(?<resource>.*)";

        if (Regex.IsMatch(url, regex))
        {
            MatchCollection collection = Regex.Matches(url, regex);

            foreach (Match m in collection)
            {
                Console.WriteLine("\nProtocol: {0} ", m.Groups["protocol"].Value);
                Console.WriteLine("Server:   {0}", m.Groups["server"].Value);
                Console.WriteLine("Resource: {0}", m.Groups["resource"].Value);
            }
        }
        else
        {
            Console.WriteLine("Invalid URL address!");
        }
    }
}