using System;

class SetOfIntegers
{
    static void Main()
    {
        try
        {
            Console.Write("The size of the set of integers: ");
            int size = int.Parse(Console.ReadLine());

            if (size >= 1)
            {
                int[] numbers = new int[size];

                for (int i = 0; i < numbers.Length; i++)
                {
                    Console.Write("element[{0}] = ", i);
                    numbers[i] = int.Parse(Console.ReadLine());
                }

                Console.WriteLine("Minimum: {0}", Minimum(numbers));
                Console.WriteLine("Maximum: {0}", Maximum(numbers));
                Console.WriteLine("Average: {0}", Average(numbers));
                Console.WriteLine("Sum: {0}", Sum(numbers));
                Console.WriteLine("Product: {0}", Product(numbers));
            }
            else
            {
                Console.WriteLine("The set of integers must have at least one element.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input!");
        }
    }

    static int Minimum(params int[] numbers)
    {
        int result = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] < result)
            {
                result = numbers[i];
            }
        }

        return result;
    }

    static int Maximum(params int[] numbers)
    {
        int result = numbers[0];

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > result)
            {
                result = numbers[i];
            }
        }

        return result;
    }

    static double Average(params int[] numbers)
    {
        double result = 0;

        foreach (int current in numbers)
        {
            result += current;
        }

        result /= numbers.Length;

        return result;
    }

    static int Sum(params int[] numbers)
    {
        int result = 0;

        foreach (int current in numbers)
        {
            result += current;
        }

        return result;
    }

    static int Product(params int[] numbers)
    {
        int result = 1;

        foreach (int current in numbers)
        {
            result *= current;
        }

        return result;
    }
}