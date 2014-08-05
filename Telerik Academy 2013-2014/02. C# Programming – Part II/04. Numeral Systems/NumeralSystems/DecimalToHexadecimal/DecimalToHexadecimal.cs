using System;

class DecimalToHexadecimal
{
    static void Main()
    {
        try
        {
            Console.Write("The decimal number to be converted: ");
            int decValue = int.Parse(Console.ReadLine());

            string hexValue = decValue.ToString("X");
            Console.WriteLine(hexValue);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}