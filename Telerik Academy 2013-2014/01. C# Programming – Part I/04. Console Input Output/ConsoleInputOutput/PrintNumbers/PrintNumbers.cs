using System;

class PrintNumbers
{
    static void Main()
    {
        try
        {
            Console.Write("n = ");
            int number = int.Parse(Console.ReadLine());

            if (number < 1)
            {
                Console.WriteLine("n must be positive.");
            }
            else
            {
                for (int i = 1; i <= number; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}