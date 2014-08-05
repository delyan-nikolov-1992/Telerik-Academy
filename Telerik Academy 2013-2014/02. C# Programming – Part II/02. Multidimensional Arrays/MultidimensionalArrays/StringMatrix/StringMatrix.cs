using System;

class StringMatrix
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
                string[,] matrix = new string[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        Console.Write("matrix[{0},{1}] = ", i, j);
                        matrix[i, j] = Console.ReadLine();
                    }
                }

                int counter = 0;
                int currentCounter = 1;
                string word = null;
                int k = 1;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        //checks for vertical sequences (top to bottom)
                        while (i + k <= matrix.GetLength(0) - 1)
                        {
                            if (matrix[i, j].Equals(matrix[i + k, j]))
                            {
                                currentCounter++;
                            }
                            else
                            {
                                break;
                            }

                            k++;
                        }

                        if (currentCounter > counter)
                        {
                            counter = currentCounter;
                            word = matrix[i, j];
                        }

                        currentCounter = 1;
                        k = 1;

                        //checks for horizontal sequences (left to right)
                        while (j + k <= matrix.GetLength(1) - 1)
                        {
                            if (matrix[i, j].Equals(matrix[i, j + k]))
                            {
                                currentCounter++;
                            }
                            else
                            {
                                break;
                            }

                            k++;
                        }

                        if (currentCounter > counter)
                        {
                            counter = currentCounter;
                            word = matrix[i, j];
                        }

                        currentCounter = 1;
                        k = 1;

                        //checks for diagonal sequences (top left to bottom right)
                        while (i + k <= matrix.GetLength(0) - 1 && j + k <= matrix.GetLength(1) - 1)
                        {
                            if (matrix[i, j].Equals(matrix[i + k, j + k]))
                            {
                                currentCounter++;
                            }
                            else
                            {
                                break;
                            }

                            k++;
                        }

                        if (currentCounter > counter)
                        {
                            counter = currentCounter;
                            word = matrix[i, j];
                        }

                        currentCounter = 1;
                        k = 1;

                        //checks for diagonal sequences (top right to bottom left)
                        while (i + k <= matrix.GetLength(0) - 1 && j - k >= 0)
                        {
                            if (matrix[i, j].Equals(matrix[i + k, j - k]))
                            {
                                currentCounter++;
                            }
                            else
                            {
                                break;
                            }

                            k++;
                        }

                        if (currentCounter > counter)
                        {
                            counter = currentCounter;
                            word = matrix[i, j];
                        }

                        currentCounter = 1;
                        k = 1;
                    }
                }

                for (int i = 0; i < counter; i++)
                {
                    Console.WriteLine(word);
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