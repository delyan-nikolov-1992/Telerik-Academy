namespace Matrix
{
    using System;

    public class Test
    {
        public static void Main()
        {
            try
            {
                Random rand = new Random();
                Matrix<int> firstMatrix = new Matrix<int>(3, 3);
                Matrix<int> secondMatrix = new Matrix<int>(3, 3);
                Matrix<double> thirdMatrix = new Matrix<double>(3, 3);

                firstMatrix[0, 0] = rand.Next(0, 15);
                firstMatrix[0, 1] = rand.Next(0, 15);
                firstMatrix[0, 2] = rand.Next(0, 15);
                firstMatrix[1, 0] = rand.Next(0, 15);
                firstMatrix[1, 1] = rand.Next(0, 15);
                firstMatrix[1, 2] = rand.Next(0, 15);
                firstMatrix[2, 0] = rand.Next(0, 15);
                firstMatrix[2, 1] = rand.Next(0, 15);
                firstMatrix[2, 2] = rand.Next(0, 15);

                secondMatrix[0, 0] = rand.Next(0, 15);
                secondMatrix[0, 1] = rand.Next(0, 15);
                secondMatrix[0, 2] = rand.Next(0, 15);
                secondMatrix[1, 0] = rand.Next(0, 15);
                secondMatrix[1, 1] = rand.Next(0, 15);
                secondMatrix[1, 2] = rand.Next(0, 15);
                secondMatrix[2, 0] = rand.Next(0, 15);
                secondMatrix[2, 1] = rand.Next(0, 15);
                secondMatrix[2, 2] = rand.Next(0, 15);

                // addition test
                Console.WriteLine("Matrix Addition (+): \n");
                Console.WriteLine(firstMatrix.ToString());
                Console.WriteLine("+\n");
                Console.WriteLine(secondMatrix.ToString());
                Console.WriteLine("=\n");
                Matrix<int> sum = firstMatrix + secondMatrix;
                Console.WriteLine(sum.ToString());

                // subtraction test
                Console.WriteLine("Matrix Subtraction (-): \n");
                Console.WriteLine(firstMatrix.ToString());
                Console.WriteLine("-\n");
                Console.WriteLine(secondMatrix.ToString());
                Console.WriteLine("=\n");
                Matrix<int> sub = firstMatrix - secondMatrix;
                Console.WriteLine(sub.ToString());

                // multiplication test
                Console.WriteLine("Matrix Multiplication (*): \n");
                Console.WriteLine(firstMatrix.ToString());
                Console.WriteLine("*\n");
                Console.WriteLine(secondMatrix.ToString());
                Console.WriteLine("=\n");
                Matrix<int> multiply = firstMatrix * secondMatrix;
                Console.WriteLine(multiply.ToString());

                // non-zero elements tests
                Console.WriteLine((firstMatrix ? "The first matrix has a non-zero element!" : "The first matrix has only zero elements!"));
                Console.WriteLine((secondMatrix ? "The second matrix has a non-zero element!" : "The second matrix has only zero elements!"));
                Console.WriteLine((thirdMatrix ? "The third matrix has a non-zero element!" : "The third matrix has only zero elements!"));
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}