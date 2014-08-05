using System;
using System.Text;

class ReverseString
{
    static void Main()
    {
        Console.Write("The string to be reversed: ");
        string input = Console.ReadLine();
        StringBuilder result = new StringBuilder();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            result.Append(input[i]);
        }

        Console.WriteLine("The reversed string: {0}", result.ToString());
    }
}