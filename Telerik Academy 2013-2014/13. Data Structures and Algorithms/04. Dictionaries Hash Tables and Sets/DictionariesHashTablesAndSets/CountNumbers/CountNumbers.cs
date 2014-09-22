namespace CountNumbers
{
    using System;
    using System.Collections.Generic;

    public class CountNumbers
    {
        public static void Main()
        {
            double[] numbers = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            IDictionary<double, int> numbersOccurrence = new Dictionary<double, int>();

            foreach (double number in numbers)
            {
                int counter = 1;

                if (numbersOccurrence.ContainsKey(number))
                {
                    counter = numbersOccurrence[number] + 1;
                }

                numbersOccurrence[number] = counter;
            }

            Console.WriteLine("The number of occurrences of each value:");

            foreach (var pair in numbersOccurrence)
            {
                Console.WriteLine("{0} -> {1} times", pair.Key, pair.Value);
            }
        }
    }
}