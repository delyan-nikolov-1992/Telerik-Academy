/*
 * 04. Write a method that finds the longest subsequence of equal numbers in given List<int> and 
 * returns the result as new List<int>. Write a program to test whether the method works correctly.
*/
namespace LongestSubsequenceEqualElements
{
    using System;
    using System.Collections.Generic;

    public class LongestSubsequenceEqualElements
    {
        public static void Main()
        {
            try
            {
                IList<int> numbers = ReadInput();
                IList<int> equalNumbers = EqualNumbers(numbers);

                Print(equalNumbers);
            }
            catch (ArgumentNullException ex)
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
                numbers.Add(currentNumber);
            }

            if (numbers.Count == 0)
            {
                throw new ArgumentNullException("There should be at least one number as input!");
            }

            return numbers;
        }

        private static IList<int> EqualNumbers(IList<int> numbers)
        {
            IList<int> equalElements = new List<int>();
            int counter = 1;
            int currentCouner = 1;
            int mostFrequentElement = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] == numbers[i - 1])
                {
                    currentCouner++;
                }
                else
                {
                    currentCouner = 1;
                }

                if (currentCouner > counter)
                {
                    counter = currentCouner;
                    mostFrequentElement = numbers[i];
                }
            }

            for (int i = 0; i < counter; i++)
            {
                equalElements.Add(mostFrequentElement);
            }

            return equalElements;
        }

        private static void Print(IList<int> numbers)
        {
            Console.WriteLine("The longest subsequence of equal elements:");

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}