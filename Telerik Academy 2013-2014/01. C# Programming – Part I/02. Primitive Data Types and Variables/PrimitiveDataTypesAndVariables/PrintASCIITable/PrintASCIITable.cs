using System;

class PrintASCIITable
{
    static void Main()
    {
        char current;

        for (int i = 0; i < 256; i++)
        {
            current = (char)i;

            Console.WriteLine(current);
        }
    }
}