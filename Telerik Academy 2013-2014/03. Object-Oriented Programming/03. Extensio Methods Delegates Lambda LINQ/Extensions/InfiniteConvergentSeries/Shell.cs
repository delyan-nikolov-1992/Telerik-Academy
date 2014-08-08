namespace InfiniteConvergentSeries
{
    using System;

    public class Shell
    {
        private const int decimals = 2;
        private const int separator = 50;

        private static bool isPositive;

        public static void Main()
        {
            try
            {
                Console.WriteLine("\"1 + 1/2 + 1/4 + 1/8 + 1/16 + ...\":");
                Console.WriteLine(ConvergentSum(index => 1 / Math.Pow(2, index - 1), decimals));
                Console.WriteLine(new string('-', separator));
                Console.WriteLine("\"1 + 1/2! + 1/3! + 1/4! + 1/5! + ...\":");
                Console.WriteLine(ConvergentSum(index => 1 / Factorial(index), decimals));
                Console.WriteLine(new string('-', separator));
                Console.WriteLine("\"1 + 1/2 - 1/4 + 1/8 - 1/16 + ...\":");
                Console.WriteLine(ConvergentSum(index => ChangeSign(1 / Math.Pow(2, index - 1)), decimals));
            }
            catch (ArgumentOutOfRangeException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private static double ConvergentSum(Func<int, double> termValue, int decimals)
        {
            double sum = 1;
            int counter = 2;
            double precision = 1.0 / Math.Pow(10, decimals);
            double current = termValue(counter);

            Console.WriteLine("\n{0}-digit precision:\n", decimals);
            Console.WriteLine("Element[{0}] = {1}", counter - 1, sum);

            while (Math.Abs(current) > precision)
            {
                Console.WriteLine("Element[{0}] = {1}", counter, current);

                sum += current;
                counter++;
                current = termValue(counter);
            }

            Console.Write("\nThe sum is ");

            return Math.Round(sum, decimals);
        }

        // calculates the factorial needed for the second infinite series
        private static double Factorial(int number)
        {
            double result = 1;

            for (long i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

        // changes the sign of a number - needed for the third infinite series
        private static double ChangeSign(double number)
        {
            double result = number;

            if (isPositive)
            {
                isPositive = false;
                result *= -1;
            }
            else
            {
                isPositive = true;
            }

            return result;
        }
    }
}