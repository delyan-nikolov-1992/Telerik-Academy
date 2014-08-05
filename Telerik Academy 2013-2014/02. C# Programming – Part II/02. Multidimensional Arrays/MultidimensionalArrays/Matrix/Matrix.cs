using System;

public class Matrix
{
    private int rows;
    private int cols;
    private int[,] matrix;

    //Constructor
    public Matrix(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;
        this.matrix = new int[rows, cols];
    }

    //Getters and Setters
    public int Rows
    {
        get { return this.rows; }
        set { this.rows = value; }
    }

    public int Cols
    {
        get { return this.cols; }
        set { this.cols = value; }
    }

    public int this[int rows, int cols]
    {
        get { return this.matrix[rows, cols]; }
        set { this.matrix[rows, cols] = value; }
    }

    // Add (+) operator
    public static Matrix operator +(Matrix firstMatrix, Matrix secondMatrix)
    {
        Matrix result = new Matrix(firstMatrix.Rows, firstMatrix.Cols);

        for (int i = 0; i < firstMatrix.Rows; i++)
        {
            for (int j = 0; j < firstMatrix.Cols; j++)
            {
                result[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
            }
        }

        return result;
    }

    // Subtract (-) operator
    public static Matrix operator -(Matrix firstMatrix, Matrix secondMatrix)
    {
        Matrix result = new Matrix(firstMatrix.Rows, firstMatrix.Cols);

        for (int i = 0; i < firstMatrix.Rows; i++)
        {
            for (int j = 0; j < firstMatrix.Cols; j++)
            {
                result[i, j] = firstMatrix[i, j] - secondMatrix[i, j];
            }
        }

        return result;
    }

    // Multiply (*) operator
    public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
    {
        Matrix result = new Matrix(firstMatrix.Rows, secondMatrix.Cols);

        for (int i = 0; i < firstMatrix.Rows; i++)
        {
            for (int j = 0; j < secondMatrix.Cols; j++)
            {
                for (int k = 0; k < firstMatrix.Cols; k++)
                {
                    result[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                }
            }
        }

        return result;
    }

    //toString() method
    public override string ToString()
    {
        string result = null;

        for (int row = 0; row < this.Rows; row++)
        {
            for (int col = 0; col < this.Cols; col++)
            {
                //can always change the whitespaces
                result += matrix[row, col] + "    ";
            }

            result += "\n";
        }

        return result;
    }
}