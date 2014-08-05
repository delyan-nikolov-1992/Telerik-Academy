using System;

class FirstBiggerInteger
{
    static void Main()
    {
        try
        {
            Console.Write("The size of the array: ");
            int size = int.Parse(Console.ReadLine());

            if (size >= 0)
            {
                int[] numbers = new int[size];

                for (int i = 0; i < size; i++)
                {
                    Console.Write("element[{0}] = ", i);
                    numbers[i] = int.Parse(Console.ReadLine());
                }

                int result = CheckNeighbors(numbers);

                Console.WriteLine(result);
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

    static int CheckNeighbors(int[] numbers)
    {
        int result = -1;

        for (int i = 1; i < numbers.Length - 1; i++)
        {
            if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i + 1])
            {
                result = i;
                break;
            }
        }

        return result;
    }
}