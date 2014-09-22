/*
 * 11. Write a program to generate all permutations with repetitions 
 * of given multi-set. For example the multi-set {1, 3, 5, 5} has the 
 * following 12 unique permutations:
 * 
 * { 1, 3, 5, 5 }   { 1, 5, 3, 5 }
 * { 1, 5, 5, 3 }   { 3, 1, 5, 5 }
 * { 3, 5, 1, 5 }   { 3, 5, 5, 1 }
 * { 5, 1, 3, 5 }   { 5, 1, 5, 3 }
 * { 5, 3, 1, 5 }   { 5, 3, 5, 1 }
 * { 5, 5, 1, 3 }   { 5, 5, 3, 1 }
 * 
 * Ensure your program efficiently avoids duplicated permutations. Test it with 
 * { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }.
*/
namespace PermutationsWithRepetitions
{
    using System;

    public class PermutationsWithRepetitions
    {
        public static void Main()
        {
            var numbers = new int[] { 1, 3, 5, 5 };
            Array.Sort(numbers);
            GeneratePermutationsWithRepetitions(numbers, 0, numbers.Length);
        }

        private static void GeneratePermutationsWithRepetitions(int[] numbers, int start, int numberOfElements)
        {
            PrintNumbers(numbers);

            for (int left = numberOfElements - 2; left >= start; left--)
            {
                for (int right = left + 1; right < numberOfElements; right++)
                {
                    if (numbers[left] != numbers[right])
                    {
                        Swap(ref numbers[left], ref numbers[right]);
                        GeneratePermutationsWithRepetitions(numbers, left + 1, numberOfElements);
                    }
                }

                var firstElement = numbers[left];

                for (int i = left; i < numberOfElements - 1; i++)
                {
                    numbers[i] = numbers[i + 1];
                }

                numbers[numberOfElements - 1] = firstElement;
            }
        }

        private static void Swap(ref int firstNumber, ref int secondNumber)
        {
            int oldFirstNumber = firstNumber;
            firstNumber = secondNumber;
            secondNumber = oldFirstNumber;
        }

        private static void PrintNumbers(int[] arr)
        {
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}