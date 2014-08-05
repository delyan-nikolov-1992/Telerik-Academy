using System;

class Permutations
{
    static void Main()
    {
        try
        {
            Console.Write("N = ");
            int size = int.Parse(Console.ReadLine());

            if (size >= 1)
            {
                int[] numbers = new int[size];

                for (int i = 1; i <= size; i++)
                {
                    numbers[i - 1] = i;
                }

                AllPermutations(numbers, 0);
            }
            else
            {
                Console.WriteLine("N must be greater than or equal to 1.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static void AllPermutations(int[] permutations, int index)
    {
        if (index == permutations.Length - 1)
        {
            for (int i = 0; i < permutations.Length; i++)
            {
                Console.Write(permutations[i] + " ");
            }

            Console.WriteLine();
        }
        else
        {
            int temp;

            for (int i = index; i < permutations.Length; i++)
            {
                temp = permutations[i];
                permutations[i] = permutations[index];
                permutations[index] = temp;
                AllPermutations(permutations, index + 1);
                temp = permutations[i];
                permutations[i] = permutations[index];
                permutations[index] = temp;
            }
        }
    }
}