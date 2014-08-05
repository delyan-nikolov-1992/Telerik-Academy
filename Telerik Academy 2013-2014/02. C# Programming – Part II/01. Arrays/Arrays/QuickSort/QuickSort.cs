using System;

class QuickSort
{
    static void Main()
    {
        try
        {
            Console.Write("The size of the array: ");
            int size = int.Parse(Console.ReadLine());

            if (size >= 0)
            {
                string[] unsorted = new string[size];

                for (int i = 0; i < unsorted.Length; i++)
                {
                    Console.Write("element[{0}] = ", i);
                    unsorted[i] = Console.ReadLine();
                }

                //sorts the array using the quick sort algorithm
                Quicksort(unsorted, 0, unsorted.Length - 1);

                //checks whether there are any elements in the array
                if (size != 0)
                {
                    Console.WriteLine("The sorted array: ");
                }

                for (int i = 0; i < unsorted.Length; i++)
                {
                    Console.WriteLine(unsorted[i]);
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

    public static void Quicksort(IComparable[] elements, int left, int right)
    {
        int i = left;
        int j = right;
        IComparable pivot = elements[(left + right) / 2];

        while (i <= j)
        {
            while (elements[i].CompareTo(pivot) < 0)
            {
                i++;
            }

            while (elements[j].CompareTo(pivot) > 0)
            {
                j--;
            }

            if (i <= j)
            {
                //swaps the elements
                IComparable tmp = elements[i];
                elements[i] = elements[j];
                elements[j] = tmp;

                i++;
                j--;
            }
        }

        //recursive calls
        if (left < j)
        {
            Quicksort(elements, left, j);
        }

        if (i < right)
        {
            Quicksort(elements, i, right);
        }
    }
}