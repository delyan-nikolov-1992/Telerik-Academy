//4. Bat'Goiko Tower from Telerik Academy Exam 1 @ 24 June 2013 Evening

using System;

class BatGoikoTower
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
        int width = 2 * height;
        char[,] tower = new char[height, width];
        int counter = 1;
        int number = 1;

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (i + j == height - 1)
                {
                    tower[i, j] = '/';
                }
                else if (height + i == j)
                {
                    tower[i, j] = '\\';
                }
                else if (i == counter && i + j >= height && height + i > j)
                {
                    tower[i, j] = '-';
                }
                else
                {
                    tower[i, j] = '.';
                }
            }

            if (i == counter)
            {
                number++;
                counter += number;
            }
        }

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write(tower[i, j]);
            }

            Console.WriteLine();
        }
    }
}