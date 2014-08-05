using System;

class HexadecimalToBinary
{
    static void Main()
    {
        try
        {
            Console.Write("The hexadecimal number to be converted: ");
            string hexValue = Console.ReadLine();

            string binValue = Convert.ToString(Convert.ToInt32(hexValue, 16), 2);
            Console.WriteLine(binValue);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}