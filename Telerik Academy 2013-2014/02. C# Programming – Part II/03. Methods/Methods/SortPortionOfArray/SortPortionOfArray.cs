using System;

class SortPortionOfArray
{
    static void Main()
    {
        try
        {
            Console.Write("The size of the array: ");
            int size = int.Parse(Console.ReadLine());

            if (size >= 1)
            {
                int[] numbers = new int[size];

                for (int i = 0; i < size; i++)
                {
                    Console.Write("element[{0}] = ", i);
                    numbers[i] = int.Parse(Console.ReadLine());
                }

                Console.Write("The starting index of the portion to be checked: ");
                int index = int.Parse(Console.ReadLine());

                if (index >= 0 && index < numbers.Length)
                {
                    int result = MaxIndex(index, numbers);

                    Console.WriteLine("\nThe max element in this portion is {0} at position {1}\n", numbers[result], result);

                    Sort(numbers);
                }
                else
                {
                    Console.WriteLine("The starting index must be an index from the array.");
                }
            }
            else
            {
                Console.WriteLine("The array must have at least one element.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static int MaxIndex(int index, int[] numbers)
    {
        int result = index;

        for (int i = index + 1; i < numbers.Length; i++)
        {
            if (numbers[i] > numbers[result])
            {
                result = i;
            }
        }

        return result;
    }

    static void Sort(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            int maxIndex = MaxIndex(i, numbers);
            int temp = numbers[i];
            numbers[i] = numbers[maxIndex];
            numbers[maxIndex] = temp;
        }

        Console.WriteLine("The array in descending order.");

        foreach (int current in numbers)
        {
            Console.WriteLine(current);
        }

        Array.Reverse(numbers);

        Console.WriteLine("\nThe array in ascending order.");

        foreach (int current in numbers)
        {
            Console.WriteLine(current);
        }
    }
}