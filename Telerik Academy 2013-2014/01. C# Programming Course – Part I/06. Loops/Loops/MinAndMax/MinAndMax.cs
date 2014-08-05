using System;

class MinAndMax
{
    static void Main()
    {
        try
        {
            Console.Write("N = ");
            int numbers = int.Parse(Console.ReadLine());
            int[] sequence = new int[numbers];

            if (numbers > 0)
            {
                for (int i = 0; i < numbers; i++)
                {
                    Console.Write((i+1) + ". number: ");
                    sequence[i] = int.Parse(Console.ReadLine());
                }

                int min = sequence[0];
                int max = sequence[0];

                for (int i = 0; i < numbers; i++)
                {
                    if (min > sequence[i])
                    {
                        min = sequence[i];
                    }

                    if (max < sequence[i])
                    {
                        max = sequence[i];
                    }
                }

                Console.WriteLine("The minimal number in this sequence is " + min);
                Console.WriteLine("The maximal number in this sequence is " + max);
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