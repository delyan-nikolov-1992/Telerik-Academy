using System;
using System.Text.RegularExpressions;

class ReplaceTags
{
    static void Main()
    {
        Console.WriteLine("The given HTML document:");
        string html = Console.ReadLine();

        Console.WriteLine(Regex.Replace(html, "<a href=\"(.*?)\">(.*?)</a>", "[URL=$1]$2[/URL]"));
    }
}