using System;

class BinaryDigits
{
    static void Main()
    {

        int number = int.Parse(Console.ReadLine());
        string[] zero = { "###", "#.#", "#.#", "###" };
        string[] one = { ".#.", "##.", ".#.", "###" };
        string representation = Convert.ToString(number, 2).PadLeft(16, '0');

        for (int i = representation.Length - 16; i < representation.Length; i++)
        {
            if (representation[i] == '0')
            {
                Console.Write(zero[0]);
            }
            else
            {
                Console.Write(one[0]);
            }

            if (i != representation.Length - 1)
            {
                Console.Write(".");
            }

        }

        Console.WriteLine();

        for (int i = representation.Length - 16; i < representation.Length; i++)
        {
            if (representation[i] == '0')
            {
                Console.Write(zero[1]);
            }
            else
            {
                Console.Write(one[1]);
            }

            if (i != representation.Length - 1)
            {
                Console.Write(".");
            }

        }

        Console.WriteLine();


        for (int i = representation.Length - 16; i < representation.Length; i++)
        {
            if (representation[i] == '0')
            {
                Console.Write(zero[2]);
            }
            else
            {
                Console.Write(one[2]);
            }

            if (i != representation.Length - 1)
            {
                Console.Write(".");
            }

        }

        Console.WriteLine();

        for (int i = representation.Length - 16; i < representation.Length; i++)
        {
            if (representation[i] == '0')
            {
                Console.Write(zero[3]);
            }
            else
            {
                Console.Write(one[3]);
            }

            if (i != representation.Length - 1)
            {
                Console.Write(".");
            }

        }


        Console.WriteLine();


    }
}