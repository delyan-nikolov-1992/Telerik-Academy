// 04. Task from Telerik Algo Academy @ October 2012
namespace ColumnOfColorBalls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class ColumnOfColorBalls
    {
        private static BigInteger result;
        private static BigInteger[] allPermutations;

        public static void Main()
        {
            string input = Console.ReadLine();
            IDictionary<char, int> letters = new Dictionary<char, int>();

            result = 0;
            allPermutations = new BigInteger[150];

            foreach (char letter in input)
            {
                int count = 1;

                if (letters.ContainsKey(letter))
                {
                    count = letters[letter] + 1;
                }

                letters[letter] = count;
            }

            int sumValues = letters.Sum(k => k.Value);
            result = CalculatePermutation(sumValues);

            foreach (var pair in letters)
            {
                BigInteger currentPermutation = CalculatePermutation(pair.Value);
                result /= currentPermutation;
            }

            Console.WriteLine(result);
        }

        private static BigInteger CalculatePermutation(int number)
        {
            if (allPermutations[number] != 0)
            {
                return allPermutations[number];
            }

            BigInteger result = 1;

            for (BigInteger i = 2; i <= number; i++)
            {
                result = result * i;
            }

            allPermutations[number] = result;

            return result;
        }
    }
}