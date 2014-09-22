/*
 * 05. Write a program that removes from given sequence all negative numbers.
*/
namespace RemoveNegativeNumbers
{
    using System;
    using System.Collections.Generic;

    public class RemoveNegativeNumbers
    {
        public static void Main()
        {
            try
            {
                List<int> numbers = ReadInput();

                numbers.RemoveAll(i => i < 0);

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

        private static void Print(IList<int> numbers)
        {
            Console.WriteLine("All non-negative numbers:");

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}