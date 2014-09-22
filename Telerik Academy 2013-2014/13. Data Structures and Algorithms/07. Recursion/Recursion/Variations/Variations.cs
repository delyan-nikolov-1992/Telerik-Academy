/*
 * 05. Write a recursive program for generating and printing all ordered 
 * k-element subsets from n-element set (variations).
 * 
 * Example: n=3, k=2, set = {hi, a, b} -> (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
*/
namespace Variations
{
    using System;

    public class Variations
    {
        private const int NumberOfElements = 3;
        private const int NumberOfChosenElements = 2;

        private static string[] elements = new string[NumberOfElements] { "hi", "a", "b" };
        private static int[] positions = new int[NumberOfChosenElements];

        public static void Main()
        {
            GenerateVariations(0);
        }

        private static void GenerateVariations(int index)
        {
            if (index >= NumberOfChosenElements)
            {
                PrintElements();
            }
            else
            {
                for (int i = 0; i < NumberOfElements; i++)
                {
                    positions[index] = i;
                    GenerateVariations(index + 1);
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