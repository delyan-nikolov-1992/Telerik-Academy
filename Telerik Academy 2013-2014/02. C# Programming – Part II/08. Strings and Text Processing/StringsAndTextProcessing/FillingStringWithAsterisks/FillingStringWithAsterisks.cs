using System;
using System.Text;

class FillingStringWithAsterisks
{
    static void Main()
    {
        Console.Write("The string to be checked: ");
        string input = Console.ReadLine();

        if (input.Length <= 20)
        {
            StringBuilder output = new StringBuilder();

            output.Append(input);

            for (int i = output.Length; i < 20; i++)
            {
                output.Append('*');
            }

            Console.WriteLine(output.ToString());
        }
        else
        {
            Console.WriteLine("The string must have maximum 20 characters.");
        }
    }
}