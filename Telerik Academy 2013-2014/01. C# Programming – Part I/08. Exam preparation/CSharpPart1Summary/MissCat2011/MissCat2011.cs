//2. Miss Cat 2011 from C# Fundamentals 2011/2012 Part 1 - Sample Exam

using System;

class MissCat2011
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int[] cats = new int[10];
        int currentVote;

        for (int i = 0; i < number; i++)
        {
            currentVote = int.Parse(Console.ReadLine());
            cats[currentVote - 1]++;
        }

        int winner = cats[0];

        for (int i = 1; i < 10; i++)
        {
            if (winner < cats[i])
            {
                winner = cats[i];
            }
        }

        for (int i = 0; i < 10; i++)
        {
            if (winner == cats[i])
            {
                Console.WriteLine(i + 1);
                break;
            }
        }

    }
}