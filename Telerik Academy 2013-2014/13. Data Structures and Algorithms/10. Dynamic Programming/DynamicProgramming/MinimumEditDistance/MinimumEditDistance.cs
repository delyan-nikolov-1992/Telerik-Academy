namespace MinimumEditDistance
{
    using System;

    public class MinimumEditDistance
    {
        private const double ReplaceLetterCoeff = 1;
        private const double DeleteLetterCoeff = 0.9;
        private const double InsertLetterCoeff = 0.8;

        public static void Main()
        {
            double cost = Compute("developer", "enveloped");
            Console.WriteLine("cost = {0}", cost);
        }

        private static double Compute(string firstString, string secondString)
        {
            int firstLength = firstString.Length;
            int secondLength = secondString.Length;
            double[,] matrix = new double[firstLength + 1, secondLength + 1];

            if (firstLength == 0)
            {
                return secondLength;
            }

            if (secondLength == 0)
            {
                return firstLength;
            }

            for (int row = 0; row <= firstLength; row++)
            {
                matrix[row, 0] = row * DeleteLetterCoeff;
            }

            for (int col = 0; col <= secondLength; col++)
            {
                matrix[0, col] = col * InsertLetterCoeff;
            }

            for (int row = 1; row <= firstLength; row++)
            {
                for (int col = 1; col <= secondLength; col++)
                {
                    if (secondString[col - 1] == firstString[row - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1];
                    }
                    else
                    {
                        matrix[row, col] = Math.Min(
                            Math.Min(matrix[row - 1, col - 1] + ReplaceLetterCoeff, matrix[row - 1, col] + DeleteLetterCoeff),
                            matrix[row, col - 1] + InsertLetterCoeff);
                    }
                }
            }

            return matrix[firstLength, secondLength];
        }
    }
}