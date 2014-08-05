using System;

class CompareArrays
{
    static void Main()
    {
        try
        {
            Console.Write("The size of the two arrays: ");
            int size = int.Parse(Console.ReadLine());

            if (size >= 0)
            {
                int[] firstSequence = new int[size];
                int[] secondSequence = new int[size];

                for (int i = 0; i < size; i++)
                {
                    Console.Write("firstSequence[{0}] = ", i);
                    firstSequence[i] = int.Parse(Console.ReadLine());
                }

                for (int i = 0; i < size; i++)
                {
                    Console.Write("secondSequence[{0}] = ", i);
                    secondSequence[i] = int.Parse(Console.ReadLine());
                }

                for (int i = 0; i < size; i++)
                {
                    if (firstSequence[i] < secondSequence[i])
                    {
                        Console.WriteLine("secondSequence[{0}] is bigger than firstSequence[{0}]", i);
                    }
                    else if (firstSequence[i] > secondSequence[i])
                    {
                        Console.WriteLine("firstSequence[{0}] is bigger than secondSequence[{0}]", i);
                    }
                    else
                    {
                        Console.WriteLine("firstSequence[{0}] and secondSequence[{0}] are equal", i);
                    }
                }
            }
            else
            {
                Console.WriteLine("The size of the arrays must be greater than or equal to 0.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}