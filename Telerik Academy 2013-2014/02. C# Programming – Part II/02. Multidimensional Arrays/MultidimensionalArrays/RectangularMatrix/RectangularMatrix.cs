using System;

class RectangularMatrix
{
    static void Main()
    {
        try
        {
            Console.Write("The rows of the matrix: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("The columns of the matrix: ");
            int cols = int.Parse(Console.ReadLine());

            if (rows >= 0 && cols >= 0)
            {
                int[,] matrix = new int[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write("matrix[{0},{1}] = ", i, j);
                        matrix[i, j] = int.Parse(Console.ReadLine());
                    }
                }

                int bestSum = int.MinValue;
                int currentSum;
                int bestRow = 0;
                int bestCol = 0;

                for (int i = 0; i < matrix.GetLength(0) - 2; i++)
                {
                    for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                    {
                        currentSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] 
                                    + matrix[i + 1, j]  + matrix[i + 1, j + 1] + matrix[i + 1, j + 2] 
                                    + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                        if (currentSum > bestSum)
                        {
                            bestSum = currentSum;
                            bestRow = i;
                            bestCol = j;
                        }
                    }
                }

                Console.WriteLine("The best sum is: {0}", bestSum);

                for (int i = bestRow; i < bestRow + 3; i++)
                {
                    for (int j = bestCol; j < bestCol + 3; j++)
                    {
                        //can always change the whitespaces
                        Console.Write("{0, 5}", matrix[i, j]);
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("The rows and the columns of the matrix must be greater than or equal to 0.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}