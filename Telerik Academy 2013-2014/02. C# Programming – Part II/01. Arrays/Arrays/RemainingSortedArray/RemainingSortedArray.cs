using System;
using System.Collections.Generic;

class RemainingSortedArray
{
    static void Main()
    {
        try
        {
            Console.Write("The size of the array: ");
            int size = int.Parse(Console.ReadLine());

            if (size >= 0)
            {
                int[] sequence = new int[size];

                for (int i = 0; i < size; i++)
                {
                    Console.Write("element[{0}] = ", i);
                    sequence[i] = int.Parse(Console.ReadLine());
                }

                List<int> currentList = new List<int>();
                List<int> maxList = new List<int>();
                int maxNumber = (int)Math.Pow(2, sequence.Length) - 1;

                for (int i = 1; i <= maxNumber; i++)
                {
                    List<int> sublist = new List<int>();

                    for (int j = 0; j < sequence.Length; j++)
                    {
                        int mask = 1 << j;
                        int nAndMask = i & mask;
                        int bit = nAndMask >> j;

                        if (bit == 1)
                        {
                            currentList.Add(sequence[j]);
                        }
                    }
                    if (isSorted(currentList))
                    {
                        if (currentList.Count > maxList.Count)
                        {
                            maxList.Clear();

                            for (int j = 0; j < currentList.Count; j++)
                            {
                                maxList.Add(currentList[j]);
                            }
                        }

                        currentList.Clear();
                    }
                    else
                    {
                        currentList.Clear();
                    }
                }

                foreach (int value in maxList)
                {
                    Console.Write(value);
                    Console.Write(' ');
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The size of the array must be greater than or equal to 0.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static bool isSorted(List<int> currentList)
    {
        for (int i = 0; i < currentList.Count - 1; i++)
        {
            if (currentList[i + 1] >= currentList[i])
            {
                continue;
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}