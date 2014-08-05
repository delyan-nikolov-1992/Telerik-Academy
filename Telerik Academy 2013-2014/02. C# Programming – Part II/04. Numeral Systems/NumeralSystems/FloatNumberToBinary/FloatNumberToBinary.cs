using System;

class FloatNumberToBinary
{
    static void Main()
    {
        try
        {
            Console.Write("The number to be converted: ");
            float value = float.Parse(Console.ReadLine());

            string binValue = FloatToBinary(value);
            PrintBinary(binValue);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static string FloatToBinary(float f)
    {
        byte[] bytes = BitConverter.GetBytes(f);
        int decNumber = BitConverter.ToInt32(bytes, 0);
        string result = Convert.ToString(decNumber, 2);

        //by the conversion the first "0"(zeros), which are before the first "1"(one), are getting lost
        //example: 00111111110011100001010001111011--->111111110011100001010001111011
        //therefore is this verification till the result has length of 32 bits
        while (result.Length < 32)
        {
            result = result.Insert(0, "0");
        }

        return result;
    }

    static void PrintBinary(string binValue)
    {
        //printing the sign of the binary number
        Console.WriteLine("sign = {0}", binValue[0]);

        //printing the exponent of the binary number
        Console.Write("exponent = ");

        for (int i = 1; i < 9; i++)
        {
            Console.Write(binValue[i]);
        }

        Console.WriteLine();

        //printg the mantissa of the binary number
        Console.Write("mantissa = ");

        for (int i = 9; i < 32; i++)
        {
            Console.Write(binValue[i]);
        }

        Console.WriteLine();
    }
}