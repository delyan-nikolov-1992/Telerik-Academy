using System;
using System.Collections.Generic;

class SubsetSumOfDefinedElements
{
    static void Main()
    {
        try
        {
            Console.Write("N = ");
            int size = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int numbers = int.Parse(Console.ReadLine());
            Console.Write("S = ");
            int sum = int.Parse(Console.ReadLine());

            if (size >= 0 && numbers >= 0 && numbers <= size)
            {
                int[] sequence = new int[size];

                for (int i = 0; i < size; i++)
                {
                    Console.Write("element[{0}] = ", i);
                    sequence[i] = int.Parse(Console.ReadLine());
                }

                int currentSum;
                int counter = 0;
                bool result = false;
                int length = power(size);
                List<int> list = new List<int>();

                for (int i = 1; i <= length; i++)
                {
                    currentSum = 0;

                    for (int j = 0; j < size; j++)
                    {
                        if (((i >> j) & 1) == 1)
                        {
                            currentSum += sequence[size - j - 1];
                            list.Add(sequence[size - j - 1]);
                            counter++;
                        }
                    }

                    if (currentSum == sum && counter == numbers)
                    {
                        //checks whether this is the first subset sum with sum S, because "yes" must be printed only once
                        if (!result)
                        {
                            Console.WriteLine("yes");
                            result = true;
                        }

                        for (int j = 0; j < list.Count; j++)
                        {
                            //simply verifications, which is important for the output
                            if (j == 0 || list[j] < 0)
                            {
                                Console.Write(list[j]);
                            }
                            else
                            {
                                Console.Write("+" + list[j]);
                            }
                        }

                        Console.WriteLine();
                    }

                    list.Clear();
                    counter = 0;
                }

                if (!result)
                {
                    Console.WriteLine("no");
                }
            }
            else
            {
                Console.WriteLine("N must be greater than or equal to 0 and K must be in the range [0; N].");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static int power(int power)
    {
        int result = 1;

        for (int i = 0; i < power; i++)
        {
            result *= 2;
        }

        return result - 1;
    }
}