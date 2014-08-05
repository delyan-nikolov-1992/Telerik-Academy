using System;

class EasterMister
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        char[,] egg = new char[2 * number, 3 * number + 1];

        for (int i = 0; i < 2 * number; i++)
        {
            for (int j = 0; j < 3 * number + 1; j++)
            {
                egg[i, j] = '.';
            }
        }


        int currentRow = 0;
        int currentCol = 3 * number / 2;
        int start = currentCol - ((number / 2) - 1);


        while (currentCol >= start)
        {

            egg[currentRow, currentCol] = '*';
            currentCol--;
        }

        currentCol--;
        currentRow++;


        while (currentCol > 1)
        {
            egg[currentRow, currentCol] = '*';

            currentRow++;
            currentCol -= 2;
        }

        egg[currentRow, currentCol] = '*';

        while (currentRow < (2 * number) - (number / 2))
        {

            egg[currentRow, currentCol] = '*';

            currentRow++;
        }
        currentCol += 2;

        while (currentRow < 2 * number)
        {

            egg[currentRow, currentCol] = '*';

            currentCol += 2;
            currentRow++;
        }

        currentCol -= 2;
        currentRow--;

        int difference = currentCol;

        int end = (3 * number + 1) / 2;

        while (currentCol <= end)
        {

            egg[currentRow, currentCol] = '*';
            currentCol++;
        }

        difference = currentCol - difference - 1;



        for (int i = 0; i < difference; i++)
        {
            egg[currentRow, currentCol] = '*';
            currentCol++;
        }

        currentCol++;
        currentRow--;


        while (currentCol < 3 * number)
        {
            egg[currentRow, currentCol] = '*';

            currentRow--;
            currentCol += 2;
        }

        currentCol -= 2;


        while (currentRow >= number / 2)
        {

            egg[currentRow, currentCol] = '*';

            currentRow--;
        }

        currentCol -= 2;


        while (currentRow >= 0)
        {

            egg[currentRow, currentCol] = '*';

            currentRow--;
            currentCol -= 2;
        }

        currentRow++;
        currentCol += 1;


        for (int i = 0; i < difference - 1; i++)
        {
            egg[currentRow, currentCol] = '*';
            currentCol--;
        }


        currentRow = number - 1;
        currentCol = 3;

        while (currentCol <= 3 * number - 3)
        {
            egg[currentRow, currentCol] = '#';
            currentCol += 2;

        }

        currentRow++;
        currentCol = 2;


        while (currentCol <= 3 * number - 2)
        {
            egg[currentRow, currentCol] = '#';
            currentCol += 2;

        }

        for (int i = 0; i < 2 * number; i++)
        {
            for (int j = 0; j < 3 * number + 1; j++)
            {
                Console.Write(egg[i, j]);
            }
            Console.WriteLine();
        }
    }
}