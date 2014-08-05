//4. Binary Digits Count from C# Fundamentals 2011/2012 Part 1 - Sample Exam

using System;

class BinaryDigitsCount
{
    static void Main()
    {
        byte bit = byte.Parse(Console.ReadLine());
        uint size = uint.Parse(Console.ReadLine());
        uint[] numbers = new uint[size];
        string representation;
        int[] counters = new int[size];
        int current;

        for (uint i = 0; i < size; i++)
        {
            numbers[i] = uint.Parse(Console.ReadLine());
            representation = Convert.ToString(numbers[i], 2);

            for (int j = 0; j < representation.Length; j++)
            {
                current = Convert.ToInt32(representation[j]) - 48;

                if (current == bit)
                {
                    counters[i]++;
                }
            }
        }

        for (uint i = 0; i < size; i++)
        {
            Console.WriteLine(counters[i]);
        }


    }
}