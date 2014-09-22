// 03. Task from Telerik Algo Academy @ October 2012
namespace Divisors
{
    using System;
    using System.Collections.Generic;

    public class Divisors
    {
        private static ICollection<int> permutations;

        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            int[] numbers = new int[length];

            for (int i = 0; i < length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            permutations = new SortedSet<int>();

            GeneratePermutations(numbers, 0);

            if (permutations.Contains(0))
            {
                Console.WriteLine(0);
                return;
            }

            if (permutations.Contains(1))
            {
                Console.WriteLine(1);
                return;
            }

            int resultNumber = 0;
            int numberOfDivisors = int.MaxValue;

            foreach (var number in permutations)
            {
                int currentDivisors = 2;

                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        currentDivisors++;
                    }
                }

                if (currentDivisors == 2)
                {
                    Console.WriteLine(number);
                    return;
                }

                if (currentDivisors < numberOfDivisors)
                {
                    numberOfDivisors = currentDivisors;
                    resultNumber = number;
                }
            }

            Console.WriteLine(resultNumber);
        }

        private static void GeneratePermutations(int[] numbers, int startPosition)
        {
            if (startPosition >= numbers.Length)
            {
                FillPermutations(numbers);
            }
            else
            {
                GeneratePermutations(numbers, startPosition + 1);

                for (int i = startPosition + 1; i < numbers.Length; i++)
                {
                    Swap(ref numbers[startPosition], ref numbers[i]);
                    GeneratePermutations(numbers, startPosition + 1);
                    Swap(ref numbers[startPosition], ref numbers[i]);
                }
            }
        }

        private static void FillPermutations(int[] arr)
        {
            int number = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                number += arr[i] * (int)Math.Pow(10, i);
            }

            permutations.Add(number);
        }

        private static void Swap(ref int first, ref int second)
        {
            int oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}