using System;

class NotDivisibleByThreeAndSeven
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
                    if (i % 3 != 0 || i % 7 != 0)
                    {
                        Console.WriteLine(i);
                    }
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