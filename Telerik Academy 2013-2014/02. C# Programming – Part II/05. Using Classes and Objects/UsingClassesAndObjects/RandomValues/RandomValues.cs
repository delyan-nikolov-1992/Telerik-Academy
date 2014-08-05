using System;

class RandomValues
{
    static void Main()
    {
        Random rand = new Random();

        for (int number = 1; number <= 10; number++)
        {
            int randomNumber = rand.Next(100, 201);
            Console.WriteLine(randomNumber);
        }
    }
}