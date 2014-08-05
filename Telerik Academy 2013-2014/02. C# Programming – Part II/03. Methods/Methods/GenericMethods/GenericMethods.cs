using System;

class GenericMethods
{
    static void Main()
    {
        Console.WriteLine("Minimum: {0}", Minimum(4, 2, 1, 3));
        Console.WriteLine("Maximum: {0}", Maximum(4, 2, 1, 3));
        //it is important to have at least one floating-point number to get the exact average of the given set of numbers
        Console.WriteLine("Average: {0}", Average(4.0, 2, 1, 3));
        Console.WriteLine("Sum: {0}", Sum(4, 2, 1, 3));
        Console.WriteLine("Product: {0}", Product(4, 2, 1, 3));
    }

    static T Minimum<T>(params T[] numbers)
    {
        dynamic result = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < result)
            {
                result = numbers[i];
            }
        }

        return result;
    }

    static T Maximum<T>(params T[] numbers)
    {
        dynamic result = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > result)
            {
                result = numbers[i];
            }
        }

        return result;
    }

    static T Average<T>(params T[] numbers)
    {
        dynamic result = 0;

        foreach (T current in numbers)
        {
            result += current;
        }

        result /= numbers.Length;

        return result;
    }

    static T Sum<T>(params T[] numbers)
    {
        dynamic result = 0;

        foreach (T current in numbers)
        {
            result += current;
        }

        return result;
    }

    static T Product<T>(params T[] numbers)
    {
        dynamic result = 1;

        foreach (T current in numbers)
        {
            result *= current;
        }

        return result;
    }
}