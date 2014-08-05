using System;

public class Shell
{
    static void Main()
    {
        try
        {
            //The usual matrix addition and subtraction is defined for two matrices of the same dimensions: (MxN) + (MxN) or (MxN) - (MxN)
            Console.Write("The rows of the two matrices must be equal for addition and subtraction: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("The cols of the two matrices must be equal for addition and subtraction: ");
            int cols = int.Parse(Console.ReadLine());

            if (rows >= 0)
            {
                Matrix firstMatrix = new Matrix(rows, cols);
                Matrix secondMatrix = new Matrix(rows, cols);

                for (int i = 0; i < firstMatrix.Rows; i++)
                {
                    for (int j = 0; j < firstMatrix.Cols; j++)
                    {
                        Console.Write("firstMatrix[{0},{1}] = ", i, j);
                        firstMatrix[i, j] = int.Parse(Console.ReadLine());
                    }
                }

                for (int i = 0; i < secondMatrix.Rows; i++)
                {
                    for (int j = 0; j < secondMatrix.Cols; j++)
                    {
                        Console.Write("secondMatrix[{0},{1}] = ", i, j);
                        secondMatrix[i, j] = int.Parse(Console.ReadLine());
                    }
                }

                // Addition Test
                Console.WriteLine("Matrix Addition (+): \n");
                Console.WriteLine(firstMatrix.ToString());
                Console.WriteLine("+\n");
                Console.WriteLine(secondMatrix.ToString());
                Console.WriteLine("=\n");
                Matrix sum = firstMatrix + secondMatrix;
                Console.WriteLine(sum.ToString());

                // Subtraction Test
                Console.WriteLine("Matrix Subtraction (-): \n");
                Console.WriteLine(firstMatrix.ToString());
                Console.WriteLine("-\n");
                Console.WriteLine(secondMatrix.ToString());
                Console.WriteLine("=\n");
                Matrix sub = firstMatrix - secondMatrix;
                Console.WriteLine(sub.ToString());

                //define new matrices to show that the multiplication works for matrices (LxM * MxN), not only for (MxN * MxN)
                Console.Write("The rows of the first matrix: ");
                int firstMatrixRows = int.Parse(Console.ReadLine());
                Console.Write("The cols of the first matrix and the rows of the second matrix must be equal for multiplication: ");
                int equalDimension = int.Parse(Console.ReadLine());
                Console.Write("The cols of the second matrix: ");
                int secondMatrixCols = int.Parse(Console.ReadLine());

                if (firstMatrixRows >= 0 && equalDimension >= 0 && secondMatrixCols >= 0)
                {
                    firstMatrix = new Matrix(firstMatrixRows, equalDimension);
                    secondMatrix = new Matrix(equalDimension, secondMatrixCols);

                    for (int i = 0; i < firstMatrix.Rows; i++)
                    {
                        for (int j = 0; j < firstMatrix.Cols; j++)
                        {
                            Console.Write("firstMatrix[{0},{1}] = ", i, j);
                            firstMatrix[i, j] = int.Parse(Console.ReadLine());
                        }
                    }

                    for (int i = 0; i < secondMatrix.Rows; i++)
                    {
                        for (int j = 0; j < secondMatrix.Cols; j++)
                        {
                            Console.Write("secondMatrix[{0},{1}] = ", i, j);
                            secondMatrix[i, j] = int.Parse(Console.ReadLine());
                        }
                    }

                    // Multiplication Test
                    Console.WriteLine("Matrix Multiplication (*): \n");
                    Console.WriteLine(firstMatrix.ToString());
                    Console.WriteLine("*\n");
                    Console.WriteLine(secondMatrix.ToString());
                    Console.WriteLine("=\n");
                    Matrix multiply = firstMatrix * secondMatrix;
                    Console.WriteLine(multiply.ToString());
                }
                else
                {
                    Console.WriteLine("The size of the matrices must be greater than or equal to 0.");
                }
            }
            else
            {
                Console.WriteLine("The size of the matrices must be greater than or equal to 0.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}