/*
 * 03. Write a program that reads a sequence of integers (List<int>) ending with 
 * an empty line and sorts them in an increasing order.
*/
namespace SortNumbers
{
    using System;
    using System.Collections.Generic;

    public class SortNumbers
    {
        public static void Main()
        {
            try
            {
                List<int> numbers = ReadInput();

                numbers.Sort();

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
            Console.WriteLine("The sorted numbers:");

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}