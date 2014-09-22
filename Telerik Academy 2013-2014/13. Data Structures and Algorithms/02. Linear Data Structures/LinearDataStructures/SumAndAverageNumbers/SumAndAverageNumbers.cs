/*
 * 01. Write a program that reads from the console a sequence of positive integer numbers.
 * The sequence ends when empty line is entered. Calculate and print the sum and average 
 * of the elements of the sequence. Keep the sequence in List<int>.
*/
namespace SumAndAverageNumbers
{
    using System;
    using System.Collections.Generic;

    public class SumAndAverageNumbers
    {
        public static void Main()
        {
            try
            {
                IList<int> numbers = ReadInput();
                int sum = Sum(numbers);
                double average = Average(numbers);

                Console.WriteLine("Sum: {0}", sum);
                Console.WriteLine("Average: {0}", average);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OverflowException)
            {
                Console.WriteLine("The input number should be in the range [{0}, {1}]", int.MinValue, int.MaxValue);
            }
            catch (FormatException)
            {
                Console.WriteLine("The input should be a positive integer!");
            }
        }

        private static IList<int> ReadInput()
        {
            IList<int> numbers = new List<int>();

            while (true)
            {
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                int currentNumber = int.Parse(input);

                if (currentNumber <= 0)
                {
                    throw new ArgumentOutOfRangeException("The input number should be positive!");
                }

                numbers.Add(currentNumber);
            }

            if (numbers.Count == 0)
            {
                throw new ArgumentNullException("There should be at least one number as input!");
            }

            return numbers;
        }

        private static int Sum(IList<int> numbers)
        {
            int sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        private static double Average(IList<int> numbers)
        {
            int sum = Sum(numbers);
            double average = (double)sum / numbers.Count;

            return average;
        }
    }
}