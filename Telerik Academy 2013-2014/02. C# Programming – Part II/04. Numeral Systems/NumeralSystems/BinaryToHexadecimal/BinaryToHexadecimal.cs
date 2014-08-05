using System;
using System.Text;

class BinaryToHexadecimal
{
    static void Main()
    {
        try
        {
            Console.Write("The binary number to be converted: ");
            string binValue = Console.ReadLine();

            StringBuilder result = new StringBuilder(binValue.Length / 8 + 1);
            int remainder = binValue.Length % 8;

            if (remainder != 0)
            {
                binValue = binValue.PadLeft(((binValue.Length / 8) + 1) * 8, '0');
            }

            for (int i = 0; i < binValue.Length; i += 8)
            {
                string eightBits = binValue.Substring(i, 8);
                result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
            }

            //removes the zeros in front of the hexadecimal number
            string hexValue = result.ToString().TrimStart('0');
            Console.WriteLine(hexValue);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}