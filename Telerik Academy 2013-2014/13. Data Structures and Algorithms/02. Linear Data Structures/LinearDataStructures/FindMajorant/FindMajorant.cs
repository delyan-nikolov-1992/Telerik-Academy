/*
 * 08. The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. 
 * Write a program to find the majorant of given array (if exists). Example:
 * 
 * {2, 2, 3, 3, 2, 3, 4, 3, 3} -> 3
*/
namespace FindMajorant
{
    using System;
    using System.Collections.Generic;

    public class FindMajorant
    {
        public static void Main()
        {
            try
            {
                int[] numbers = ReadInput();
                int? majorant = FindMajorantNumber(numbers);

                Print(majorant);
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
                Console.WriteLine("The input should be a valid integer!");
            }
        }

        private static int[] ReadInput()
        {
            Console.Write("The number of integers = ");
            int size = int.Parse(Console.ReadLine());

            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("The number of integers should be a positive number!");
            }

            int[] numbers = new int[size];

            for (int i = 0; i < size; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                numbers[i] = currentNumber;
            }

            return numbers;
        }

        private static IDictionary<int, int> CountNumbers(int[] numbers)
        {
            IDictionary<int, int> numbersCount = new Dictionary<int, int>();

            foreach (var number in numbers)
            {
                int count = 1;

                if (numbersCount.ContainsKey(number))
                {
                    count = numbersCount[number] + 1;
                }

                numbersCount[number] = count;
            }

            return numbersCount;
        }

        private static int? FindMajorantNumber(int[] numbers)
        {
            IDictionary<int, int> numbersCount = CountNumbers(numbers);
            int minTimesOfOccurrence = (numbers.Length / 2) + 1;

            foreach (var pair in numbersCount)
            {
                if (pair.Value >= minTimesOfOccurrence)
                {
                    return pair.Key;
                }
            }

            return null;
        }

        private static void Print(int? majorant)
        {
            if (majorant == null)
            {
                Console.WriteLine("There is no majorant!");
            }
            else
            {
                Console.WriteLine("The majorant is {0}.", majorant);
            }
        }
    }
}