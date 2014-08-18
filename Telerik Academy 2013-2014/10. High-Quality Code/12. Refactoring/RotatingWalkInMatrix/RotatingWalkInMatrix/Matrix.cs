namespace RotatingWalkInMatrix
{
    using System;

    public class Matrix
    {
        public static void Main()
        {
            Console.Write("n = ");
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = FillMatrix(size);

            PrintMatrix(matrix);
        }

        public static int[,] FillMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            int counter = 1;
            int x = 0;
            int y = 0;
            int dx = 1;
            int dy = 1;

            while (true)
            {
                matrix[x, y] = counter;

                if (!IsValidMove(matrix, x, y))
                {
                    FindCell(matrix, out x, out y);

                    if (x != 0 && y != 0)
                    {
                        counter++;
                        dx = 1;
                        dy = 1;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }

                while (x + dx >= matrix.GetLength(0) || x + dx < 0
                    || y + dy >= matrix.GetLength(1) || y + dy < 0 || matrix[x + dx, y + dy] != 0)
                {
                    ChangeDirection(ref dx, ref dy);
                }

                x += dx;
                y += dy;
                counter++;
            }

            return matrix;
        }

        public static void ChangeDirection(ref int dx, ref int dy)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int newDirection = 0;

            for (int i = 0; i < 8; i++)
            {
                if (dirX[i] == dx && dirY[i] == dy)
                {
                    newDirection = i;
                    break;
                }
            }

            if (newDirection == 7)
            {
                dx = dirX[0];
                dy = dirY[0];
                return;
            }

            dx = dirX[newDirection + 1];
            dy = dirY[newDirection + 1];
        }

        public static bool IsValidMove(int[,] matrix, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= matrix.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (y + dirY[i] >= matrix.GetLength(1) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }

                if (matrix[x + dirX[i], y + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static void FindCell(int[,] matrix, out int x, out int y)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        x = i;
                        y = j;
                        return;
                    }
                }
            }

            x = 0;
            y = 0;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0}", matrix[i, j]).PadLeft(2).PadRight(3));
                }

                Console.WriteLine();
            }
        }
    }
}