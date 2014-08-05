using System;

class CountNumber
{
    static void Main()
    {
        try
        {
            Console.Write("The number to be checked: ");
            int number = int.Parse(Console.ReadLine());
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

                int counter = Count(number, sequence);

                Console.WriteLine("The given number appears {0} times.", counter);
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

    static int Count(int number, int[] sequence)
    {
        int counter = 0;

        foreach (int currentNumber in sequence)
        {
            if (number == currentNumber)
            {
                counter++;
            }
        }

        return counter;
    }
}