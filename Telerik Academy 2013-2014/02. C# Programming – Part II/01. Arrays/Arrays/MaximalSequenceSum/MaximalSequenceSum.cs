using System;

class MaximalSequenceSum
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

                int currentMaxSum = sequence[0];
                int maxSum = sequence[0];
                int begin = 0;
                int beginTemp = 0;
                int end = 0;

                for (int i = 1; i < size; i++)
                {
                    if (maxSum < 0)
                    {
                        maxSum = sequence[i];
                        beginTemp = i;
                    }
                    else
                    {
                        maxSum += sequence[i];
                    }

                    if (maxSum > currentMaxSum)
                    {
                        currentMaxSum = maxSum;
                        begin = beginTemp;
                        end = i;
                    }
                }

                Console.WriteLine("The maximal sum of a sequence is " + maxSum);

                for (int i = begin; i <= end; i++)
                {
                    Console.WriteLine("element[{0}] = {1}", i, sequence[i]);
                }
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
}