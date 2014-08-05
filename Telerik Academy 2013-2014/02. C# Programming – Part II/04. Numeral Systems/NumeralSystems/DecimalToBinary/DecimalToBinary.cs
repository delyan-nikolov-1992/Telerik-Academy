using System;

class DecimalToBinary
{
    static void Main()
    {
        try
        {
            Console.Write("The decimal number to be converted: ");
            int decValue = int.Parse(Console.ReadLine());

            string binValue = Convert.ToString(decValue, 2);
            Console.WriteLine(binValue);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}