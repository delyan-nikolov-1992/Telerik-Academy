using System;

class BiggerNeighbor
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

                Console.Write("The position of the element to be checked: ");
                int position = int.Parse(Console.ReadLine());

                if (position >= 0 && position < numbers.Length)
                {
                    CheckNeighbors(numbers, position);
                }
                else
                {
                    Console.WriteLine("The position of the element must be in the range of the array.");
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

    static void CheckNeighbors(int[] numbers, int position)
    {
        if (position == 0 || position == numbers.Length - 1)
        {
            Console.WriteLine("The element does not have two neighbors.");
        }
        else
        {
            if (numbers[position] > numbers[position - 1] && numbers[position] > numbers[position + 1])
            {
                Console.WriteLine("The element is bigger than its two neighbors.");
            }
            else
            {
                Console.WriteLine("The element is not bigger than its two neighbors.");
            }
        }
    }
}