using System;

class ElementsMultipliedByFive
{
    static void Main()
    {
        int[] numbers = new int[20];

        for (int i = 0; i < 20; i++)
        {
            numbers[i] = i * 5;
            Console.WriteLine("element[{0}] = {1}", i, numbers[i]);
        }
    }
}