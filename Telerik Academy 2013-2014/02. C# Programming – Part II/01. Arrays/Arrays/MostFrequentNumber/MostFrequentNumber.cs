using System;
using System.Collections.Generic;

class MostFrequentNumber
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

                //using List<int> because the maximal frequent numbers can be two or more
                List<int> intList = new List<int>();
                int counter = 0;
                int currentCounter = 0;

                for (int i = 0; i < size; i++)
                {
                    for (int j = i; j < size; j++)
                    {
                        if (sequence[i] == sequence[j])
                        {
                            currentCounter++;
                        }
                    }

                    if (currentCounter > counter)
                    {
                        intList.Clear();
                        intList.Add(sequence[i]);
                        counter = currentCounter;
                    }
                    else if (currentCounter == counter)
                    {
                        intList.Add(sequence[i]);
                    }

                    currentCounter = 0;
                }

                for (int i = 0; i < intList.Count; i++)
                {
                    Console.WriteLine(intList[i]);
                }

                //when the most frequent number is found only one, we say "one time", not "one times"
                if (counter == 1)
                {
                    Console.WriteLine(counter + " time");
                }
                else
                {
                    Console.WriteLine(counter + " times");
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