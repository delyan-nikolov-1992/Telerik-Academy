using System;

class PrintNumbers
{
    static void Main()
    {
        try
        {
            Console.Write("N = ");
            int numbers = int.Parse(Console.ReadLine());

            if (numbers > 0)
            {
                for (int i = 1; i <= numbers; i++)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine("N must be positive.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}