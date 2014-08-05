//2. Drunken Numbers from Telerik Academy Exam 1 @ 23 June 2013

using System;

class DrunkenNumbers
{
    static void Main()
    {
        int numberOfRounds = int.Parse(Console.ReadLine());
        int[] rounds = new int[numberOfRounds];
        int firstPlayer = 0;
        int secondPlayer = 0;
        int current;
        int counter = 0;
        int middleNumber = 0;

        for (int i = 0; i < numberOfRounds; i++)
        {
            rounds[i] = int.Parse(Console.ReadLine());

            if (rounds[i] < 0)
            {
                rounds[i] *= -1;
            }

        }

        for (int i = 0; i < numberOfRounds; i++)
        {
            current = rounds[i];

            while (current / 10 != 0)
            {

                counter++;
                current /= 10;
            }

            counter++;

            for (int j = 0; j < counter; j++)
            {
                current = rounds[i] % 10;
                rounds[i] /= 10;



                if (counter % 2 == 0)
                {
                    if (j >= counter / 2)
                    {
                        firstPlayer += current;
                    }
                    else
                    {
                        secondPlayer += current;
                    }
                }
                else
                {
                    if (j + 1 > counter / 2 + 1)
                    {
                        firstPlayer += current;
                    }
                    else if (j + 1 <= counter / 2)
                    {
                        secondPlayer += current;
                    }
                    else
                    {
                        middleNumber += 2 * current;
                    }
                }
            }

            counter = 0;
        }

        if (firstPlayer > secondPlayer)
        {
            Console.WriteLine("M " + (firstPlayer - secondPlayer));
        }
        else if (firstPlayer < secondPlayer)
        {
            Console.WriteLine("V " + (secondPlayer - firstPlayer));
        }
        else
        {
            Console.WriteLine("No " + (firstPlayer + secondPlayer + middleNumber));
        }

    }
}