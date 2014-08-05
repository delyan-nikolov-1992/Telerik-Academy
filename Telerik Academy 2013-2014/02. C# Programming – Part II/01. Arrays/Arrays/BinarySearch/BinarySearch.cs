using System;

class BinarySearch
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

                Console.Write("The given element: ");
                int element = int.Parse(Console.ReadLine());

                Array.Sort(sequence);
                int max = size - 1;
                int min = 0;
                int mid;
                bool result = false;

                while (max >= min && (!result))
                {
                    mid = (min + max) / 2;
                    if (sequence[mid] == element)
                    {
                        Console.WriteLine("The element is on position " + mid);
                        result = true;
                    }
                    else if (sequence[mid] < element)
                    {
                        min = mid + 1;
                    }
                    else
                    {
                        max = mid - 1;
                    }
                }

                if (!result)
                {
                    Console.WriteLine("The element was not found in the array.");
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