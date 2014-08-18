using System;

public class Number
{
    private const int SIZE = 100;
    private const int FOUND_VALUE = 666;

    // third task
    private void FindNumber()
    {
        int foundValue;

        for (int i = 0; i < SIZE; i++)
        {
            Console.WriteLine(array[i]);

            if (i % 10 == 0)
            {
                if (array[i] == expectedValue)
                {
                    foundValue = FOUND_VALUE;
                    break;
                }
            }
        }

        // More code here
        if (foundValue == FOUND_VALUE)
        {
            Console.WriteLine("Value Found");
        }
    }
}