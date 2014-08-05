using System;

class PrintMatrix
{
    static void Main()
    {
        try
        {
            Console.Write("N = ");
            int number = int.Parse(Console.ReadLine());

            if (number > 0 && number < 20)
            {
                int current = number;
                int totalWidth = 2;

                if (number > 5)
                {
                    totalWidth = 3;
                }

                for (int i = 1; i <= number; i++)
                {
                    for (int j = i; j <= current; j++)
                    {
                        Console.Write(j.ToString().PadRight(totalWidth, ' '));
                    }

                    Console.WriteLine();
                    current++;
                }
            }
            else
            {
                Console.WriteLine("N must be in the intervall (0;20).");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}