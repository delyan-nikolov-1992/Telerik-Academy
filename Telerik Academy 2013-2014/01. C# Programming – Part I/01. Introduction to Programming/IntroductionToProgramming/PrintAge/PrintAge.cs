using System;

class PrintAge
{
    static void Main()
    {
        try
        {
            int age = int.Parse(Console.ReadLine()) + 10;
            Console.WriteLine(age);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}