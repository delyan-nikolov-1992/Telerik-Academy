/*
 * 01. Write a recursive program that simulates the execution of n nested loops from 1 to n. Examples:
 * 
 *                            1 1 1
 *                            1 1 2
 *                            1 1 3
 *          1 1               1 2 1
 * n=2  ->  1 2      n=3  ->  ...
 *          2 1               3 2 3
 *          2 2               3 3 1               
 *                            3 3 2                 
 *                            3 3 3
 */
namespace NestedLoops
{
    using System;

    public class NestedLoops
    {
        private const int NumberOfLoops = 2;

        private static int[] numbers = new int[NumberOfLoops];

        public static void Main()
        {
            ExecuteNestedLoops(0);
        }

        private static void ExecuteNestedLoops(int index)
        {
            if (index >= NumberOfLoops)
            {
                PrintNumbers();
            }
            else
            {
                for (int i = 1; i <= NumberOfLoops; i++)
                {
                    numbers[index] = i;
                    ExecuteNestedLoops(index + 1);
                }
            }
        }

        private static void PrintNumbers()
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}