using System;

class MaximalSum
{
    static void Main()
    {
        try
        {
            Console.Write("The size of the array: ");
            int size = int.Parse(Console.ReadLine());
            Console.Write("The number of the elements: ");
            int elements = int.Parse(Console.ReadLine());

            if (size >= 0 && elements >= 0 && elements <= size)
            {
                int[] sequence = new int[size];
                int sum = 0;

                for (int i = 0; i < size; i++)
                {
                    Console.Write("element[{0}] = ", i);
                    sequence[i] = int.Parse(Console.ReadLine());
                }

                Array.Sort(sequence);

                //checks whether K > 0 because when K = 0 there are no numbers that we search for
                if (elements != 0)
                {
                    Console.WriteLine("The biggest K numbers are:");
                }

                for (int i = 0; i < elements; i++)
                {
                    Console.WriteLine(sequence[size - i - 1]);
                    sum += sequence[size - i - 1];
                }

                Console.WriteLine("The sum is " + sum);
            }
            else
            {
                Console.WriteLine("N must be greater than or equal to 0 and K must be in the intervall [0; N].");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}