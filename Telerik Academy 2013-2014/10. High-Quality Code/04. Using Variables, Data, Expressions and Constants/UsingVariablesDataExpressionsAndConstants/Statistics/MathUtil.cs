namespace Statistics
{
    using System;

    public class MathUtil
    {
        public void PrintStatistics(double[] numbers, int size)
        {
            double maxNumber = double.MinValue;
            double minNumber = double.MaxValue;
            double sum = 0;
            double average;

            for (int i = 0; i < size; i++)
            {
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i];
                }

                if (numbers[i] < minNumber)
                {
                    minNumber = numbers[i];
                }

                sum += numbers[i];
            }

            average = sum / size;

            this.PrintMax(maxNumber);
            this.PrintMin(minNumber);
            this.PrintAvg(average);
        }

        private void PrintMax(double maxNumber)
        {
            Console.WriteLine("The max number is: {0}", maxNumber);
        }

        private void PrintMin(double minNumber)
        {
            Console.WriteLine("The min number is: {0}", minNumber);
        }

        private void PrintAvg(double average)
        {
            Console.WriteLine("The average is: {0}", average);
        }
    }
}