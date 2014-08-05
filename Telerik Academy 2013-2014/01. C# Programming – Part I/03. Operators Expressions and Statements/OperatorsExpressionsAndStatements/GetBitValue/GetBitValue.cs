using System;

class GetBitValue
{
    static void Main()
    {
        try
        {
            Console.Write("The number to be checked: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("The position to be checked: ");
            int position = int.Parse(Console.ReadLine());

            int mask = 1 << position;
            int result = number & mask;
            int bit = result >> position;

            Console.WriteLine(bit);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}