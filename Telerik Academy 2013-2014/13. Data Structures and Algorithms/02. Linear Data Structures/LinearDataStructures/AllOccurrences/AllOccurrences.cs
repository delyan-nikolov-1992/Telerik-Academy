/*
 * 07. Write a program that finds in given array of integers (all belonging to the range [0..1000]) 
 * how many times each of them occurs.
 * 
 * Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
 * 
 * 2 -> 2 times
 * 3 -> 4 times
 * 4 -> 3 times
*/
namespace AllOccurrences
{
    using System;
    using System.Collections.Generic;

    public class AllOccurrences
    {
        private const int MinValue = 0;
        private const int MaxValue = 1000;

        public static void Main()
        {
            try
            {
                int[] numbers = ReadInput();
                IDictionary<int, int> numbersCount = CountNumbers(numbers);

                Print(numbersCount);
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

                if (currentNumber < MinValue || currentNumber > MaxValue)
                {
                    throw new ArgumentOutOfRangeException(string.Format(
                        "The input number should be in the range[{0}, {1}]",
                        MinValue,
                        MaxValue));
                }

                numbers[i] = currentNumber;
            }

            return numbers;
        }

        private static IDictionary<int, int> CountNumbers(int[] numbers)
        {
            IDictionary<int, int> numbersCount = new SortedDictionary<int, int>();

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

        private static void Print(IDictionary<int, int> numbersCount)
        {
            foreach (var pair in numbersCount)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}