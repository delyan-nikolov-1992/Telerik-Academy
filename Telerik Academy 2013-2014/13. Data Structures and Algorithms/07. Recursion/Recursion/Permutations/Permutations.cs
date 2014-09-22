/*
 * 04. Write a recursive program for generating and printing all permutations 
 * of the numbers 1, 2, ..., n for given integer number n. Example:
 * 
 * n=3 -> {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}
*/
namespace Permutations
{
    using System;

    public class Permutations
    {
        public static void Main()
        {
            int[] numbers = { 1, 2, 3 };
            GeneratePermutations(numbers, 0);
        }

        private static void GeneratePermutations(int[] numbers, int index)
        {
            if (index >= numbers.Length)
            {
                PrintNumbers(numbers);
            }
            else
            {
                GeneratePermutations(numbers, index + 1);

                for (int i = index + 1; i < numbers.Length; i++)
                {
                    SwapNumbers(ref numbers[index], ref numbers[i]);
                    GeneratePermutations(numbers, index + 1);
                    SwapNumbers(ref numbers[index], ref numbers[i]);
                }
            }
        }

        private static void SwapNumbers(ref int firstNumber, ref int secondNumber)
        {
            int oldFirstNumber = firstNumber;
            firstNumber = secondNumber;
            secondNumber = oldFirstNumber;
        }

        private static void PrintNumbers(int[] numbers)
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}