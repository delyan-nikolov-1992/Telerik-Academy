using System;

class SequenceOfGivenSum
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

                Console.Write("S = ");
                int sum = int.Parse(Console.ReadLine());
                int currentSum = 0;

                for (int i = 0; i < size; i++)
                {
                    for (int j = i; j < size; j++)
                    {
                        currentSum += sequence[j];

                        if (currentSum == sum)
                        {
                            Console.WriteLine();

                            for (int k = i; k <= j; k++)
                            {
                                Console.WriteLine("element[{0}] = {1}", k, sequence[k]);
                            }
                        }
                    }

                    currentSum = 0;
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