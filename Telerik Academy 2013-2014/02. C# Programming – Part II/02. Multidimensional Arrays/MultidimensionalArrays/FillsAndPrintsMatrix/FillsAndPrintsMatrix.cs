using System;

class FillsAndPrintsMatrix
{
    static void Main()
    {
        try
        {
            Console.Write("The size of the matrix: ");
            int size = int.Parse(Console.ReadLine());

            if (size >= 0)
            {
                int[,] matrix = new int[size, size];
                int position = 1;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[j, i] = position;
                        position++;
                    }
                }

                Console.WriteLine("a)");
                Printing(matrix);

                position = 1;
                int k = 0;
                bool changePosition = false;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[k, i] = position;
                        position++;

                        if (j == size - 1)
                        {
                            if (changePosition)
                            {
                                changePosition = false;
                            }
                            else
                            {
                                changePosition = true;
                            }
                        }
                        else
                        {
                            if (changePosition)
                            {
                                k--;
                            }
                            else
                            {
                                k++;
                            }
                        }
                    }
                }

                Console.WriteLine("b)");
                Printing(matrix);

                position = 1;
                int row = size - 1;
                int col = 0;

                for (int i = 0; i < size * size; i++)
                {
                    matrix[row, col] = position;
                    row++;
                    col++;
                    position++;

                    if (row == size || col == size)
                    {
                        row--;

                        if (col == size)
                        {
                            row--;
                            col--;
                        }

                        while (row > 0 && col > 0)
                        {
                            row--;
                            col--;
                        }
                    }
                }

                Console.WriteLine("c)");
                Printing(matrix);

                position = 1;
                int counter = size;
                int value = -size;
                int sum = -1;

                do
                {
                    value = -1 * value / size;

                    for (int i = 0; i < counter; i++)
                    {
                        sum += value;
                        matrix[sum % size, sum / size] = position++;
                    }

                    value *= size;
                    counter--;

                    for (int i = 0; i < counter; i++)
                    {
                        sum += value;
                        matrix[sum % size, sum / size] = position++;
                    }
                } while (counter > 0);

                Console.WriteLine("d)");
                Printing(matrix);
            }
            else
            {
                Console.WriteLine("The size of the matrix must be greater than or equal to 0.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static void Printing(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                //can always change the whitespaces
                Console.Write("{0, 5}", matrix[i, j]);
            }

            Console.WriteLine();
        }
    }
}