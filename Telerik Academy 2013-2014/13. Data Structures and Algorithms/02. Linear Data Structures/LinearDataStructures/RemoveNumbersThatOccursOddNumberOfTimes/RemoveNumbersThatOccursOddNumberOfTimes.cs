/*
 * 06. Write a program that removes from given sequence all numbers that occur odd number of times. Example:
 * 
 * {4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2} -> {5, 3, 3, 5}
*/
namespace RemoveNumbersThatOccursOddNumberOfTimes
{
    using System;
    using System.Collections.Generic;

    public class RemoveNumbersThatOccursOddNumberOfTimes
    {
        public static void Main()
        {
            try
            {
                List<int> numbers = ReadInput();
                RemoveOddElements(numbers);

                Print(numbers);
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

        private static List<int> ReadInput()
        {
            List<int> numbers = new List<int>();

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

        private static void RemoveOddElements(List<int> numbers)
        {
            List<int> elementsOccuredOddNumberOfTimes = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int counter = 0;

                for (int j = 0; j < numbers.Count; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        counter++;
                    }
                }

                if (counter % 2 != 0 && !elementsOccuredOddNumberOfTimes.Contains(numbers[i]))
                {
                    elementsOccuredOddNumberOfTimes.Add(numbers[i]);
                }
            }

            numbers.RemoveAll(i => elementsOccuredOddNumberOfTimes.Contains(i));
        }

        private static void Print(IList<int> numbers)
        {
            if (numbers.Count == 0)
            {
                Console.WriteLine("All elements occur odd number of times!");
            }
            else
            {
                Console.WriteLine("All elements that don't occur odd number of times:");

                foreach (var number in numbers)
                {
                    Console.WriteLine(number);
                }
            }
        }
    }
}