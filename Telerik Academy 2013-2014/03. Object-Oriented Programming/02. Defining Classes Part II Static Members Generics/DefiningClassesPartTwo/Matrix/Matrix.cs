namespace Matrix
{
    using System;
    using System.Text;

    public class Matrix<T> where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        private int rows;
        private int cols;
        private T[,] matrix;

        // Constructor
        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.matrix = new T[rows, cols];
        }

        // Getters and Setters
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

        public T this[int rows, int cols]
        {
            get
            {
                if (!isInRange(rows, cols))
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }

                return this.matrix[rows, cols];
            }
            set
            {
                if (!isInRange(rows, cols))
                {
                    throw new IndexOutOfRangeException("Index out of range!");
                }

                this.matrix[rows, cols] = value;
            }
        }

        // Add (+) operator
        public static Matrix<T> operator +(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if ((firstMatrix.rows != secondMatrix.rows) || (firstMatrix.cols != secondMatrix.cols))
            {
                throw new ArgumentOutOfRangeException("The matrices must have the same size!");
            }

            Matrix<T> result = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);

            for (int i = 0; i < firstMatrix.Rows; i++)
            {
                for (int j = 0; j < firstMatrix.Cols; j++)
                {
                    result[i, j] = (dynamic)firstMatrix[i, j] + secondMatrix[i, j];
                }
            }

            return result;
        }

        // Subtract (-) operator
        public static Matrix<T> operator -(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if ((firstMatrix.rows != secondMatrix.rows) || (firstMatrix.cols != secondMatrix.cols))
            {
                throw new ArgumentOutOfRangeException("The matrices must have the same size!");
            }

            Matrix<T> result = new Matrix<T>(firstMatrix.Rows, firstMatrix.Cols);

            for (int i = 0; i < firstMatrix.Rows; i++)
            {
                for (int j = 0; j < firstMatrix.Cols; j++)
                {
                    result[i, j] = (dynamic)firstMatrix[i, j] - secondMatrix[i, j];
                }
            }

            return result;
        }

        // Multiply (*) operator
        public static Matrix<T> operator *(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.cols != secondMatrix.rows)
            {
                throw new ArgumentOutOfRangeException("The matrices must have the same size!");
            }

            Matrix<T> result = new Matrix<T>(firstMatrix.Rows, secondMatrix.Cols);

            for (int i = 0; i < firstMatrix.Rows; i++)
            {
                for (int j = 0; j < secondMatrix.Cols; j++)
                {
                    for (int k = 0; k < firstMatrix.Cols; k++)
                    {
                        result[i, j] += (dynamic)firstMatrix[i, k] * secondMatrix[k, j];
                    }
                }
            }

            return result;
        }

        // true operator overload
        public static bool operator true(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.cols; j++)
                {
                    if ((dynamic)matrix[i, j] != default(T))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // false oprator overload
        public static bool operator false(Matrix<T> matrix)
        {
            for (int i = 0; i < matrix.rows; i++)
            {
                for (int j = 0; j < matrix.cols; j++)
                {
                    if ((dynamic)matrix[i, j] != default(T))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // checks whether the given position is in the range of the matrix
        private bool isInRange(int row, int col)
        {
            if ((row < 0) || (row >= this.rows) || (col < 0) || (col >= this.cols))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // toString() method
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    // can always change the whitespaces
                    result.AppendFormat("{0,5}", this[i, j]);
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}