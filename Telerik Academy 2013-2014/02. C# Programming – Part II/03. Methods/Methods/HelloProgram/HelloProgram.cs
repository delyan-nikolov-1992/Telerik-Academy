using System;

class HelloProgram
{
    static void Main()
    {
        try
        {
            Console.Write("Your name: ");
            string name = Console.ReadLine();

            PrintName(name);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static void PrintName(string name)
    {
        Console.WriteLine("Hello, {0}!", name);
    }
}