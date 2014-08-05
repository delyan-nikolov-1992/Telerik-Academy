using System;

class EqualNeighbors
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

                int counter = 0;
                int currentCounter = 0;
                int BestElement = matrix[0, 0];
                bool[,] visited = new bool[matrix.GetLength(0), matrix.GetLength(1)];

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        currentCounter = FindPath(matrix, i, j, matrix[i, j], visited);

                        if (currentCounter > counter)
                        {
                            BestElement = matrix[i, j];
                            counter = currentCounter;
                        }
                    }
                }

                Console.WriteLine("There are {0} equal neighbor elements and the element is {1}.", counter, BestElement);
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

    static bool inRange(int[,] matrix, int row, int col, bool[,] visited)
    {
        bool inRange = false;

        if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
        {
            inRange = true;
        }

        if (inRange)
        {
            if (visited[row, col] == true)
            {
                inRange = false;
            }
        }

        return inRange;
    }

    static int FindPath(int[,] matrix, int row, int col, int value, bool[,] visited)
    {
        int counter = 0;

        if (inRange(matrix, row, col, visited))
        {
            if (matrix[row, col] == value)
            {
                counter++;
                visited[row, col] = true;

                //the program works also for diagonal neighbors
                counter += FindPath(matrix, row - 1, col - 1, value, visited); //up and left
                counter += FindPath(matrix, row - 1, col, value, visited); //up
                counter += FindPath(matrix, row - 1, col + 1, value, visited); //up and right
                counter += FindPath(matrix, row, col + 1, value, visited); //right
                counter += FindPath(matrix, row + 1, col + 1, value, visited); //down and right
                counter += FindPath(matrix, row + 1, col, value, visited); //down
                counter += FindPath(matrix, row + 1, col - 1, value, visited); //down and left
                counter += FindPath(matrix, row, col - 1, value, visited); //left
            }
        }

        return counter;
    }
}