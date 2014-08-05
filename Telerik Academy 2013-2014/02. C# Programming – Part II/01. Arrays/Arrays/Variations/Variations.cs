using System;

class Variations
{
    static void Main()
    {
        try
        {
            Console.Write("N = ");
            int size = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int numbers = int.Parse(Console.ReadLine());

            if (size >= 1 && numbers >= 0)
            {
                int[] variations = new int[numbers];
                AllVariations(variations, 0, size);
            }
            else
            {
                Console.WriteLine("N must be greater than or equal to 1 and K must be greater than or equal to 0.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static void AllVariations(int[] variations, int index, int size)
    {
        if (index == variations.Length)
        {
            for (int i = 0; i < variations.Length; i++)
            {
                Console.Write(variations[i] + " ");
            }

            Console.WriteLine();
        }
        else
        {
            for (int i = 1; i <= size; i++)
            {
                variations[index] = i;
                AllVariations(variations, index + 1, size);
            }
        }
    }
}