using System;

class TwoGirlsOnePath
{
    static void Main()
    {
        long[] cells = Array.ConvertAll(Console.ReadLine().Split(new char[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries), long.Parse);

        Winner(cells);
    }

    static void Winner(long[] cells)
    {
        long mollyCounter = cells[0];
        long dollyCounter = cells[cells.Length - 1];
        long mollyPosition = mollyCounter % (cells.Length);
        long dollyPosition = (cells.Length - 1 - dollyCounter) % (cells.Length);
        cells[cells.Length - 1] = 0;
        cells[0] = 0;

        while (dollyPosition < 0)
        {
            dollyPosition += cells.Length;
        }

        bool draw = false;
        bool printMolly = false;
        bool printDolly = false;

        if (mollyCounter == 0 && dollyCounter == 0)
        {
            draw = true;
        }
        else if (mollyCounter == 0)
        {
            printDolly = true;
        }
        else if (dollyCounter == 0)
        {
            printMolly = true;
        }
        else
        {
            while (true)
            {
                if (cells[mollyPosition] == 0 && cells[dollyPosition] == 0)
                {
                    draw = true;
                    break;
                }
                else if (cells[mollyPosition] == 0)
                {
                    printDolly = true;
                    dollyCounter += cells[dollyPosition];

                    break;
                }
                else if (cells[dollyPosition] == 0)
                {
                    printMolly = true;
                    mollyCounter += cells[mollyPosition];

                    break;
                }
                else if (mollyPosition == dollyPosition)
                {

                    mollyCounter += (cells[mollyPosition] / 2);
                    dollyCounter += (cells[dollyPosition] / 2);
                    long current = mollyPosition;

                    mollyPosition = (mollyPosition + cells[mollyPosition]) % (cells.Length);
                    dollyPosition = (dollyPosition - cells[dollyPosition]) % (cells.Length);

                    while (dollyPosition < 0)
                    {
                        dollyPosition += cells.Length;
                    }

                    if (cells[current] % 2 == 0)
                    {
                        cells[current] = 0;
                    }
                    else
                    {
                        cells[current] = 1;
                    }
                }
                else
                {
                    //Console.WriteLine("Moly cells:" +cells[mollyPosition]);
                    //Console.WriteLine("Doly cells:" + cells[dollyPosition]);
                    //Console.WriteLine("Moly Pos:" + mollyPosition);
                    //Console.WriteLine("Doly Pos:" + dollyPosition);



                    //Console.WriteLine("Moly cells:" + cells[mollyPosition]);
                    //Console.WriteLine("Doly cells:" + cells[dollyPosition]);
                    //Console.WriteLine("Moly Pos:" + mollyPosition);
                    //Console.WriteLine("Doly Pos:" + dollyPosition);
                    mollyCounter += cells[mollyPosition];
                    dollyCounter += cells[dollyPosition];
                    long current = mollyPosition;
                    long current2 = dollyPosition;

                    mollyPosition = (mollyPosition + cells[mollyPosition]) % (cells.Length);
                    dollyPosition = (dollyPosition - cells[dollyPosition]) % (cells.Length);

                    while (dollyPosition < 0)
                    {
                        dollyPosition += cells.Length;
                    }

                    cells[current] = 0;
                    cells[current2] = 0;
                }
            }

        }

        if (draw)
        {
            Console.WriteLine("Draw");
        }
        else if (printMolly)
        {
            Console.WriteLine("Molly");
        }
        else if (printDolly)
        {
            Console.WriteLine("Dolly");
        }

        Console.WriteLine("{0} {1}", mollyCounter, dollyCounter);
    }
}