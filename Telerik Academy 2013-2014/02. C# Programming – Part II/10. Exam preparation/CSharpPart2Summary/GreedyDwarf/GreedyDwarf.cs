// 2. Greedy Dwarf from C# Part 2 - 2012/2013 @ 4 Feb 2013 - Morning

using System;

class GreedyDwarf
{
    static void Main()
    {
        string[] valley = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int size = int.Parse(Console.ReadLine());
        int maxCoins = int.MinValue;

        for (int i = 0; i < size; i++)
        {
            string[] currentPattern = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int currentCoins = CurrentPatternCoins(valley, currentPattern);

            if (currentCoins > maxCoins)
            {
                maxCoins = currentCoins;
            }
        }

        Console.WriteLine(maxCoins);
    }

    static int CurrentPatternCoins(string[] valley, string[] currentPattern)
    {
        bool[] visited = new bool[valley.Length];
        int j = 0;
        int result = int.Parse(valley[j]);
        bool exit = false;
        visited[j] = true;

        while (!exit)
        {
            foreach (string current in currentPattern)
            {
                j += int.Parse(current);

                if (j >= 0 && j < valley.Length && !visited[j])
                {
                    result += int.Parse(valley[j]);
                    visited[j] = true;
                }
                else
                {
                    exit = true;
                    break;
                }
            }
        }

        return result;
    }
}