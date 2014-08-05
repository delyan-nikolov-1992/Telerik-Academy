using System;

class HexadecimalToDecimal
{
    static void Main()
    {
        try
        {
            Console.Write("The hexadecimal number to be converted: ");
            string hexValue = Console.ReadLine();

            int decValue = Convert.ToInt32(hexValue, 16);
            Console.WriteLine(decValue);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}