using System;

class DogeCoin
{
    static void Main()
    {
        string[] current = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int rows = int.Parse(current[0]);
        int cols = int.Parse(current[1]);
        int[,] matrix = new int[rows, cols];
        int coins = int.Parse(Console.ReadLine());

        for (int i = 0; i < coins; i++)
        {
            string[] current2 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            matrix[int.Parse(current2[0]), int.Parse(current2[1])] = 1;
        }

        ////calculate the solution for bottom and right
        //for (int i = matrix.GetLength(0) - 2; i >= 0; i--)
        //{
        //    matrix[matrix.GetLength(0) - 1, i] += matrix[matrix.GetLength(0) - 1, i + 1];
        //    matrix[i, matrix.GetLength(0) - 1] += matrix[i + 1, matrix.GetLength(0) - 1];
        //}

        for (int i = matrix.GetLength(0) - 2; i >= 0; i--)
        {
            for (int j = matrix.GetLength(1) - 2; j >= 0; j--)
            {
                matrix[i, j] += Math.Max(matrix[i + 1, j], matrix[i, j + 1]);
            }
        }

        //for (int i = matrix.GetLength(0) - 2; i >= 0; i--)
        //{
        //    for (int j = matrix.GetLength(1) - 2; j >= 0; j--)
        //    {
        //        Console.Write(matrix[i, j] + "  ");
        //    }
        //    Console.WriteLine();
        //}

        Console.WriteLine(matrix[0, 0]);
    }
}