using System;

class SelectionSort
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
                int minElement;
                int temp;

                for (int i = 0; i < size; i++)
                {
                    Console.Write("element[{0}] = ", i);
                    sequence[i] = int.Parse(Console.ReadLine());
                }

                for (int i = 0; i < size - 1; i++)
                {
                    minElement = i;

                    for (int j = i + 1; j < size; j++)
                    {
                        if (sequence[j] < sequence[minElement])
                        {
                            minElement = j;
                        }
                    }

                    if (minElement != i)
                    {
                        temp = sequence[i];
                        sequence[i] = sequence[minElement];
                        sequence[minElement] = temp;
                    }
                }

                //checks whether there are any elements in the array
                if (size != 0)
                {
                    Console.WriteLine("The sorted array: ");
                }

                for (int i = 0; i < size; i++)
                {
                    Console.WriteLine(sequence[i]);
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