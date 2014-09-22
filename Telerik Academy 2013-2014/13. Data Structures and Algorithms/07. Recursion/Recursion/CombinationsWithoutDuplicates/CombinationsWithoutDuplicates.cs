/*
 * 03. Modify the previous program to skip duplicates:
 * 
 * n=4, k=2 -> (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
*/
namespace CombinationsWithoutDuplicates
{
    using System;

    public class CombinationsWithoutDuplicates
    {
        private const int NumberOfAllElements = 4;
        private const int NumberOfChosenElements = 2;

        private static int[] numbers = new int[NumberOfChosenElements];

        public static void Main()
        {
            GenerateCombinationsWithoutRepetitions(0, 1);
        }

        private static void GenerateCombinationsWithoutRepetitions(int index, int start)
        {
            if (index >= NumberOfChosenElements)
            {
                PrintNumbers();
            }
            else
            {
                for (int i = start; i <= NumberOfAllElements; i++)
                {
                    numbers[index] = i;
                    GenerateCombinationsWithoutRepetitions(index + 1, i + 1);
                }
            }
        }

        private static void PrintNumbers()
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}