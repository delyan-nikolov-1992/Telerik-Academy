/*
 * 05. Write a program for generating and printing all subsets of k strings from given set of strings.
 * 
 * Example: s = {test, rock, fun}, k=2 -> (test rock),  (test fun),  (rock fun)
*/
namespace SubsetsOfStrings
{
    using System;

    public class SubsetsOfStrings
    {
        private const int NumberOfElements = 3;
        private const int NumberOfChosenElements = 2;

        private static string[] elements = new string[NumberOfElements] { "test", "rock", "fun" };
        private static int[] positions = new int[NumberOfChosenElements];

        public static void Main()
        {
            GenerateCombinationsNoRepetitions(0, 0);
        }

        private static void GenerateCombinationsNoRepetitions(int index, int start)
        {
            if (index >= NumberOfChosenElements)
            {
                PrintElements();
            }
            else
            {
                for (int i = start; i < NumberOfElements; i++)
                {
                    positions[index] = i;
                    GenerateCombinationsNoRepetitions(index + 1, i + 1);
                }
            }
        }

        private static void PrintElements()
        {
            for (int i = 0; i < positions.Length; i++)
            {
                Console.Write(elements[positions[i]] + " ");
            }

            Console.WriteLine();
        }
    }
}