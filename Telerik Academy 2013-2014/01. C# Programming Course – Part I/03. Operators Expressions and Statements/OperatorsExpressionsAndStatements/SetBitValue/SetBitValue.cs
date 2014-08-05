using System;

class SetBitValue
{
    static void Main()
    {
        try
        {
            Console.Write("The number to be changed: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("The position to be reversed: ");
            int position = int.Parse(Console.ReadLine());
            Console.Write("The bit value to be given: ");
            byte bitValue = byte.Parse(Console.ReadLine());

            int mask = 1 << position;
            int result;

            if (bitValue == 0)
            {
                mask = ~mask;
                result = number & mask;

                Console.WriteLine(result + " (" + Convert.ToString(result, 2).PadLeft(8, '0') + ")");
            }
            else if (bitValue == 1)
            {
                result = number | mask;

                Console.WriteLine(result + " (" + Convert.ToString(result, 2).PadLeft(8, '0') + ")");
            }
            else
                Console.WriteLine("The bit value must be 0 or 1.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}