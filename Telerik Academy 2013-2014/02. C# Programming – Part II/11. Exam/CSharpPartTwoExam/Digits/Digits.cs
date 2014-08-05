using System;

class Digits
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int[,] matrix = new int[size, size];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            string[] current = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = int.Parse(current[j]);
            }
        }

        int result = CheckOnes(matrix) + CheckEight(matrix);

        Console.WriteLine(result);
    }

    static int CheckOnes(int[,] matrix)
    {
        int result = 0;

        for (int i = 1; i < matrix.GetLength(0) - 2; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 2; j++)
            {
                if (i - 2 >= 0
                    && matrix[i, j] == 1 && matrix[i - 1, j + 1] == 1 && matrix[i - 2, j + 2] == 1
                    && matrix[i - 1, j + 2] == 1 && matrix[i, j + 2] == 1 && matrix[i + 1, j + 2] == 1
                    && matrix[i + 2, j + 2] == 1)
                {
                    result += 1;
                }
                else if (i + 3 < matrix.GetLength(1)
                  && matrix[i, j] == 2 && matrix[i - 1, j + 1] == 2 && matrix[i, j + 2] == 2
                  && matrix[i + 1, j + 2] == 2 && matrix[i + 2, j + 1] == 2 && matrix[i + 3, j] == 2
                  && matrix[i + 3, j + 1] == 2 && matrix[i + 3, j + 2] == 2)
                {
                    result += 2;
                }
            }
        }

        return result;
    }


    static int CheckEight(int[,] matrix)
    {
        int result = 0;

        for (int i = 0; i < matrix.GetLength(0) - 4; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 2; j++)
            {
                if (matrix[i, j] == 3 && matrix[i, j + 1] == 3 && matrix[i, j + 2] == 3
                           && matrix[i + 1, j + 2] == 3 && matrix[i + 2, j + 1] == 3 && matrix[i + 2, j + 2] == 3
                          && matrix[i + 3, j + 2] == 3 && matrix[i + 4, j] == 3 && matrix[i + 4, j + 1] == 3
                          && matrix[i + 4, j + 2] == 3)
                {

                    result += 3;
                }
                else if (matrix[i, j] == 4 && matrix[i, j + 2] == 4 && matrix[i + 1, j] == 4
              && matrix[i + 1, j + 2] == 4 && matrix[i + 2, j] == 4 && matrix[i + 2, j + 1] == 4
              && matrix[i + 2, j + 2] == 4 && matrix[i + 3, j + 2] == 4 && matrix[i + 4, j + 2] == 4)
                {
                    result += 4;
                }
                else if (matrix[i, j] == 5 && matrix[i, j + 1] == 5 && matrix[i, j + 2] == 5
              && matrix[i + 1, j] == 5 && matrix[i + 2, j] == 5 && matrix[i + 2, j + 1] == 5
              && matrix[i + 2, j + 2] == 5 && matrix[i + 3, j + 2] == 5 && matrix[i + 4, j] == 5
              && matrix[i + 4, j + 1] == 5 && matrix[i + 4, j + 2] == 5)
                {
                    result += 5;
                }
                else if (matrix[i, j] == 6 && matrix[i, j + 1] == 6 && matrix[i, j + 2] == 6
              && matrix[i + 1, j] == 6 && matrix[i + 2, j] == 6 && matrix[i + 2, j + 1] == 6
              && matrix[i + 2, j + 2] == 6 && matrix[i + 3, j] == 6 && matrix[i + 3, j + 2] == 6
              && matrix[i + 4, j] == 6 && matrix[i + 4, j + 1] == 6 && matrix[i + 4, j + 2] == 6)
                {
                    result += 6;
                }
                else if (matrix[i, j] == 7 && matrix[i, j + 1] == 7 && matrix[i, j + 2] == 7
              && matrix[i + 1, j + 2] == 7 && matrix[i + 2, j + 1] == 7 && matrix[i + 3, j + 1] == 7
              && matrix[i + 4, j + 1] == 7)
                {
                    result += 7;
                }
                else if (matrix[i, j] == 9 && matrix[i, j + 1] == 9 && matrix[i, j + 2] == 9
                  && matrix[i + 1, j] == 9 && matrix[i + 1, j + 2] == 9 && matrix[i + 2, j + 1] == 9
                  && matrix[i + 2, j + 2] == 9 && matrix[i + 3, j + 2] == 9 && matrix[i + 4, j] == 9
                  && matrix[i + 4, j + 1] == 9 && matrix[i + 4, j + 2] == 9)
                {
                    result += 9;
                }
                else if (matrix[i, j] == 8 && matrix[i, j + 1] == 8 && matrix[i, j + 2] == 8
                  && matrix[i + 1, j] == 8 && matrix[i + 1, j + 2] == 8 && matrix[i + 2, j + 1] == 8
                  && matrix[i + 3, j] == 8 && matrix[i + 3, j + 2] == 8 && matrix[i + 4, j] == 8
                  && matrix[i + 4, j + 1] == 8 && matrix[i + 4, j + 2] == 8)
                {
                    result += 8;
                }
            }
        }

        return result;
    }
}