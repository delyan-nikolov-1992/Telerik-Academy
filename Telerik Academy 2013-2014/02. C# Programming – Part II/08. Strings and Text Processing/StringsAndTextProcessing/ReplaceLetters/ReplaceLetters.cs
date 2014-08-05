using System;
using System.Text;

class ReplaceLetters
{
    static void Main()
    {
        Console.WriteLine("Write the text:");
        string text = Console.ReadLine();

        StringBuilder output = new StringBuilder();
        bool same = false;

        for (int i = 0; i < text.Length - 1; i++)
        {
            if (char.IsLetter(text[i]))
            {
                if (text[i].Equals(text[i + 1]))
                {
                    same = true;
                }
                else if (same)
                {
                    output.Append(text[i]);
                    same = false;
                }
                else
                {
                    output.Append(text[i]);
                }
            }
            else
            {
                output.Append(text[i]);
            }
        }

        output.Append(text[text.Length - 1]);

        Console.WriteLine("\nThe new text:");
        Console.WriteLine(output.ToString());
    }
}