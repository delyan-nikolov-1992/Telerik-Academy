using System;
using System.Collections.Generic;

class MaximalSequenceOfEqualElements
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

                //using List<int> because the maximal sequences of equal elements can be two or more
                //Example: {2, 1, 1, 2, 3, 3, 3, 2, 2, 2, 1} ---> {3, 3, 3}, {2, 2, 2}
                List<int> intList = new List<int>();
                int currentElement;
                int counter = 1;
                int currentCounter = 1;

                for (int i = 0; i < size; i++)
                {
                    Console.Write("element[{0}] = ", i);
                    numbers[i] = int.Parse(Console.ReadLine());
                }

                currentElement = numbers[0];
                intList.Add(numbers[0]);

                for (int i = 1; i < size; i++)
                {
                    if (currentElement == numbers[i])
                    {
                        currentCounter++;
                    }
                    else
                    {
                        currentElement = numbers[i];
                        currentCounter = 1;
                    }

                    if (currentCounter > counter)
                    {
                        counter = currentCounter;
                        intList.Clear();
                        intList.Add(currentElement);
                    }
                    else if (currentCounter == counter)
                    {
                        intList.Add(currentElement);
                    }
                }

                for (int i = 0; i < intList.Count; i++)
                {
                    for (int j = 0; j < counter; j++)
                    {
                        Console.WriteLine(intList[i]);
                    }
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