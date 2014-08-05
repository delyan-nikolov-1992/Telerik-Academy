using System;

class IsoscelesTriangle
{
    static void Main()
    {
        int blank = 2;
        int symbol = 1;
        char copyright = '\u00A9';

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < blank; j++)
            {
                Console.Write(' ');
            }

            for (int j = 0; j < symbol; j++)
            {
                Console.Write(copyright);
            }

            blank -= 1;
            symbol += 2;

            Console.WriteLine();
        }
    }
}