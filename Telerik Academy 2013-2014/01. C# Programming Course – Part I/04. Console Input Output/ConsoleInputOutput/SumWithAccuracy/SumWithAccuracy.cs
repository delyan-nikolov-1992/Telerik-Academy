using System;

class SumWithAccuracy
{
    static void Main()
    {
        double current;
        double sum = 1;

        for (double i = 2; i <= 1000; i++)
        {
            if (i % 2 == 0)
            {
                current = 1 / i;
            }
            else
            {
                current = -(1 / i);
            }

            sum += current;
        }

        Console.WriteLine("The sum is: " + sum);
    }
}