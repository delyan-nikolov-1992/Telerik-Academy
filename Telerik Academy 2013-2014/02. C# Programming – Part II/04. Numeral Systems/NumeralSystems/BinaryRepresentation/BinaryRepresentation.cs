using System;

class BinaryRepresentation
{
    static void Main()
    {
        try
        {
            Console.Write("The number to be converted: ");
            short value = short.Parse(Console.ReadLine());

            string binValue = Convert.ToString(value, 2);
            Console.WriteLine(binValue);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}