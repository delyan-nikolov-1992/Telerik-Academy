using System;
using System.Text;

class UnicodeCharacters
{
    static void Main()
    {
        Console.WriteLine("The given text:");
        string text = Console.ReadLine();

        Console.WriteLine(GetUnicodeString(text));
    }

    static string GetUnicodeString(string text)
    {
        StringBuilder unicodeChars = new StringBuilder();

        foreach (char currentChar in text)
        {
            unicodeChars.Append("\\u");
            unicodeChars.Append(String.Format("{0:x4}", (int)currentChar));
        }

        return unicodeChars.ToString();
    }
}