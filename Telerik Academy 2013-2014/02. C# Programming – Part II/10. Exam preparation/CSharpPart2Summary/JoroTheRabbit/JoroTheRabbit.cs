// 2. Joro the Rabbit from C# Part 2 - 2012/2013 @ 5 Feb 2013

using System;

class JoroTheRabbit
{
    static void Main()
    {
        int[] terrain = Array.ConvertAll(Console.ReadLine().Split(new char[] { ',', ' ' },
            StringSplitOptions.RemoveEmptyEntries), int.Parse);

        MaxPositions(terrain);
    }

    static void MaxPositions(int[] terrain)
    {
        int result = 1;

        for (int i = 0; i < terrain.Length; i++)
        {
            for (int k = 1; k < terrain.Length; k++)
            {
                int currentLength = 1;
                int j = i;

                while (true)
                {
                    int current = terrain[j];
                    j += k;

                    if (j >= terrain.Length)
                    {
                        j -= terrain.Length;
                    }

                    if (terrain[j] > current)
                    {
                        currentLength++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentLength > result)
                {
                    result = currentLength;
                }
            }
        }

        Console.WriteLine(result);
    }
}