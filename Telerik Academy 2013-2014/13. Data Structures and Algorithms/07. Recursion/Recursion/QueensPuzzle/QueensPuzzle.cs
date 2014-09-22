/*
 * 12. Write a recursive program to solve the "8 Queens Puzzle" with backtracking. 
 * Learn more at: http://en.wikipedia.org/wiki/Eight_queens_puzzle
*/
namespace QueensPuzzle
{
    using System;

    public class QueensPuzzle
    {
        private const int NumberOfQueens = 8;

        private static int[] position = new int[NumberOfQueens];
        private static int numberOfSolutions = 0;

        public static void Main()
        {
            Solve(0);
            Console.WriteLine("All solutions of the {0}-queens problem are {1}.", NumberOfQueens, numberOfSolutions);
        }

        private static void Solve(int row)
        {
            if (row == NumberOfQueens)
            {
                numberOfSolutions++;
            }
            else
            {
                for (int col = 0; col < NumberOfQueens; col++)
                {
                    if (IsSafe(row, col))
                    {
                        position[row] = col;
                        Solve(row + 1);
                    }
                }
            }
        }

        private static bool IsSafe(int row, int col)
        {
            for (int i = 1; i <= row; i++)
            {
                int other = position[row - i];

                if (other == col || other == col - i || other == col + i)
                {
                    return false;
                }
            }

            return true;
        }
    }
}