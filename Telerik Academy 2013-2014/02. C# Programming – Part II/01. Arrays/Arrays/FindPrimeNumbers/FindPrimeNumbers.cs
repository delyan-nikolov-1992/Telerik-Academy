using System;

class FindPrimeNumbers
{
    static void Main()
    {
        int size = 10000000;

        //by default they are all false
        bool[] numbers = new bool[size];

        //sets all numbers to true
        for (int i = 2; i < size; i++)
        {
            numbers[i] = true;
        }

        //weeds out the non primes by finding mutiples 
        for (int j = 2; j < size; j++)
        {
            if (numbers[j])
            {
                for (int p = 2; (p * j) < size; p++)
                {
                    numbers[p * j] = false;
                }
            }
        }

        Console.WriteLine("All prime numbers in the range [0; 10 000 000]:");

        for (int i = 2; i < size; i++)
        {
            if (numbers[i])
            {
                Console.WriteLine(i);
            }
        }
    }
}