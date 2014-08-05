using System;

class Combinations
{
    static void Main()
    {
        try
        {
            Console.Write("N = ");
            int size = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int numbers = int.Parse(Console.ReadLine());

            if (size >= 1 && numbers >= 0 && numbers <= size)
            {
                int[] combinations = new int[numbers];
                AllCombinations(combinations, 0, 1, size);
            }
            else
            {
                Console.WriteLine("N must be greater than or equal to 1 and K must be in the range [0; N].");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static void AllCombinations(int[] combinations, int index, int currentNumber, int size)
    {
        if (index == combinations.Length)
        {
            for (int i = 0; i < combinations.Length; i++)
            {
                Console.Write(combinations[i] + " ");
            }

            Console.WriteLine();
        }
        else
        {
            for (int i = currentNumber; i <= size; i++)
            {
                combinations[index] = i;
                AllCombinations(combinations, index + 1, i + 1, size);
            }
        }
    }
}