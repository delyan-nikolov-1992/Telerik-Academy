using System;

class LargestNumber
{
    static void Main()
    {
        try
        {
            Console.Write("N = ");
            int size = int.Parse(Console.ReadLine());
            Console.Write("K = ");
            int number = int.Parse(Console.ReadLine());

            if (size >= 0)
            {
                int[] sequence = new int[size];

                for (int i = 0; i < size; i++)
                {
                    Console.Write("element[{0}] = ", i);
                    sequence[i] = int.Parse(Console.ReadLine());
                }

                Array.Sort(sequence);
                int index = Array.BinarySearch(sequence, number);

                if (index == -1)
                {
                    Console.WriteLine("There is no such number, that is less than or equal to K.");
                }
                else if (index < -1)
                {
                    int realIndex = ~index - 1;
                    Console.WriteLine("The largest number, which is less than or equal to K is {0}", sequence[realIndex]);
                }
                else if (index >= 0)
                {
                    Console.WriteLine("The largest number, which is less than or equal to K is {0}", sequence[index]);
                }
            }
            else
            {
                Console.WriteLine("N must be greater than or equal to 0.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}