using System;

class ThirdBit
{
    static void Main()
    {
        try
        {
            Console.Write("The number to be checked: ");
            int number = int.Parse(Console.ReadLine());

            int position = 3;
            int mask = 1 << position;
            int result = number & mask;
            int bit = result >> position;
            bool isOne = true;

            if (bit == 0)
                isOne = false;

            Console.WriteLine(isOne);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}