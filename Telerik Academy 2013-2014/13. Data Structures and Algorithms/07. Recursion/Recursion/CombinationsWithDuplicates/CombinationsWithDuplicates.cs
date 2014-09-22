/*
 * 02. Write a recursive program for generating and printing all the combinations 
 * with duplicates of k elements from n-element set. Example:
 * 
 * n=3, k=2 -> (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
*/
namespace CombinationsWithDuplicates
{
    using System;

    public class CombinationsWithDuplicates
    {
        private const int NumberOfAllElements = 3;
        private const int NumberOfChosenElements = 2;

        private static int[] numbers = new int[NumberOfChosenElements];

        public static void Main()
        {
            GenerateCombinationsWithRepetitions(0, 1);
        }

        private static void GenerateCombinationsWithRepetitions(int index, int start)
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
                    GenerateCombinationsWithRepetitions(index + 1, i);
                }
            }
        }

        private static void PrintNumbers()
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}