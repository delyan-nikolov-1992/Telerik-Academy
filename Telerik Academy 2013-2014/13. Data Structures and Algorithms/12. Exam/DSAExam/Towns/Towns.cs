namespace Towns
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Linq;

    public class Towns
    {
        const int NO_PREVIOUS = -1;
        private static int result = 0;

        public static void Main()
        {
            try
            {
                int numberOfCities = int.Parse(Console.ReadLine());

                var cities = new int[numberOfCities];
                int[] lis = new int[cities.Length];
                int[] back = new int[cities.Length];

                bool allTheSame = true;

                for (int i = 0; i < numberOfCities; i++)
                {
                    var line = Console.ReadLine().Split(' ');

                    var population = int.Parse(line[0]);
                    cities[i] = population;

                    if (i != 0 && cities[i] != cities[i - 1])
                    {
                        allTheSame = false;
                    }
                }

                if (allTheSame)
                {
                    Console.WriteLine(1);
                    return;
                }

                for (int i = 0; i < cities.Length; i++)
                {
                    back[i] = NO_PREVIOUS;
                }

                int bestIndex = CalculateLongestIncreasingSubsequence(cities, lis, back);

                //Console.WriteLine("arr = " + String.Join(", ", cities));
                //Console.WriteLine("lis = " + String.Join(", ", lis));
                //Console.WriteLine("back = " + String.Join(", ", back));

                PrintLongestIncreasingSubsequence(cities, back, bestIndex);

                // DECREASING

                var decreasingCities = cities.ToList().GetRange(bestIndex, cities.Length - (bestIndex + 1));
                decreasingCities.Reverse();
                var decreasingCitiesAsArray = decreasingCities.ToArray();
                var decreasingLis = new int[decreasingCitiesAsArray.Length];
                var decreasingBack = new int[decreasingCitiesAsArray.Length];

                for (int i = 0; i < decreasingCitiesAsArray.Length; i++)
                {
                    decreasingBack[i] = NO_PREVIOUS;
                }

                int newBestIndex = CalculateLongestIncreasingSubsequence(decreasingCitiesAsArray, decreasingLis, decreasingBack);

                PrintLongestIncreasingSubsequence(decreasingCitiesAsArray, decreasingBack, newBestIndex);

                Console.WriteLine(result);
            }
            catch (Exception)
            {
                Console.WriteLine(result);
            }
        }

        private static int CalculateLongestIncreasingSubsequence(int[] arr, int[] lis, int[] back)
        {
            int bestF = 0;
            int bestIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                lis[i] = 1;
                for (int k = 0; k <= i - 1; k++)
                {
                    if (arr[k] < arr[i])
                    {
                        if (lis[k] + 1 > lis[i])
                        {
                            lis[i] = lis[k] + 1;
                            back[i] = k;
                            if (lis[i] > bestF)
                            {
                                bestF = lis[i];
                                bestIndex = i;
                            }
                        }
                    }
                }
            }
            return bestIndex;
        }

        static void PrintLongestIncreasingSubsequence(int[] arr, int[] back, int index)
        {
            List<int> lis = new List<int>();
            while (index != NO_PREVIOUS)
            {
                lis.Add(arr[index]);
                index = back[index];
            }
            lis.Reverse();
            // Console.WriteLine("subsequence = " + String.Join(" ", lis));
            result += lis.Count;
        }
    }
}