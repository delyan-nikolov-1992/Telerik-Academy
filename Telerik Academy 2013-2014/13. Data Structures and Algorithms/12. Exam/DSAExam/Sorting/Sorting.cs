namespace Sorting
{
    using System;

    public class Sorting
    {
        private static int Counter = 0;

        public static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            var numbers = new int[length];

            var line = Console.ReadLine().Split(' ');

            for (int i = 0; i < length; i++)
            {
                numbers[i] = int.Parse(line[i]);
            }

            int allowedNumbers = int.Parse(Console.ReadLine());
            insertionSort(ref numbers);

            if (allowedNumbers > 2)
            {
                int remainder = Counter % allowedNumbers;
                Counter /= allowedNumbers;
                Counter += remainder;
            }

            Console.WriteLine(Counter);
        }

        public static void insertionSort(ref int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int value = numbers[i];
                int j = i - 1;

                while (j >= 0 && numbers[j] > value)
                {
                    numbers[j + 1] = numbers[j];
                    Counter++;
                    j--;
                }

                numbers[j + 1] = value;
            }
        }
    }
}