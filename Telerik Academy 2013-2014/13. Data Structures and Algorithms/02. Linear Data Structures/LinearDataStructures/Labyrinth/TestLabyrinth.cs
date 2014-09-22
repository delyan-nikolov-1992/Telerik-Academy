namespace Labyrinth
{
    using System;

    public class TestLabyrinth
    {
        private static int[,] labyrinth = new int[,] 
                                            {
                                                { 0, 0, 0, -1, 0, -1 },
                                                { 0, -1, 0, -1, 0, -1 },
                                                { 0, -2, -1, 0, -1, 0 },
                                                { 0, -1, 0, 0, 0, 0 },
                                                { 0, 0, 0, -1, -1, 0 },
                                                { 0, 0, 0, -1, 0, -1 }
                                            };

        public static void Main()
        {
            var startRow = 0;
            var startCol = 0;

            FindStart(ref startRow, ref startCol);
            Solve(startRow, startCol, 0);
            PrintAswer();
        }

        private static void Solve(int row, int col, int step)
        {
            if (row < 0 || col < 0 || row >= labyrinth.GetLength(0) || 
                col >= labyrinth.GetLength(1) || labyrinth[row, col] == -1)
            {
                return;
            }

            if (labyrinth[row, col] < step && labyrinth[row, col] > 0)
            {
                return;
            }

            if (labyrinth[row, col] == 0 || labyrinth[row, col] > step)
            {
                labyrinth[row, col] = step;
            }

            step++;

            Solve(row + 1, col, step);
            Solve(row - 1, col, step);
            Solve(row, col + 1, step);
            Solve(row, col - 1, step);
        }

        private static void FindStart(ref int startRow, ref int startCol)
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] == -2)
                    {
                        startRow = i;
                        startCol = j;

                        return;
                    }
                }
            }
        }

        private static void PrintAswer()
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] == -2)
                    {
                        Console.Write(" *");
                    }
                    else if (labyrinth[i, j] == -1)
                    {
                        Console.Write(" x");
                    }
                    else if (labyrinth[i, j] == 0)
                    {
                        Console.Write(" u");
                    }
                    else
                    {
                        Console.Write(" " + labyrinth[i, j]);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}