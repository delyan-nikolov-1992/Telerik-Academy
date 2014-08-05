using System;

class MenuTasks
{
    static void Main()
    {
        try
        {
            int option;

            do
            {
                Console.Write("MENU:\n" +
                        "1. Reverses the digits of a number\n" +
                        "2. Calculates the average of a sequence of integers\n" +
                        "3. Solves a linear equation a * x + b = 0\n" +
                        "4. End of the program\n" +
                        "Your choice is: ");
                option = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (option)
                {
                    case 1:
                        ReverseNumber();
                        break;
                    case 2:
                        Average();
                        break;
                    case 3:
                        LinearEquation();
                        break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("There are only 4 options.\n");
                        break;
                }
            } while (option != 4);
        }
        catch (FormatException)
        {
            Console.Clear();
            Console.WriteLine("Invalid input!\n");
        }
    }

    static void ReverseNumber()
    {
        decimal number;

        do
        {
            Console.Write("The decimal non-negative number to be reversed: ");
            number = decimal.Parse(Console.ReadLine());

            if (number < 0)
            {
                Console.Clear();
                Console.WriteLine("The decimal number should be non-negative.\n");
            }
        } while (number < 0);

        decimal result = 0;
        string representation = number.ToString();
        char[] digits = representation.ToCharArray();

        Array.Reverse(digits);

        result = decimal.Parse(new string(digits));

        Console.WriteLine("The reversed decimal number: {0}\n", result);
    }

    static void Average()
    {
        int size;

        do
        {
            Console.Write("The size of the non-empty sequence: ");
            size = int.Parse(Console.ReadLine());

            if (size < 1)
            {
                Console.Clear();
                Console.WriteLine("The sequence should not be empty.\n");
            }
        } while (size < 1);

        int[] sequence = new int[size];
        Console.WriteLine();

        for (int i = 0; i < sequence.Length; i++)
        {
            Console.Write("element[{0}] = ", i);
            sequence[i] = int.Parse(Console.ReadLine());
        }

        double result = 0;

        for (int i = 0; i < sequence.Length; i++)
        {
            result += sequence[i];
        }

        result /= sequence.Length;

        Console.WriteLine("\nThe average of the sequence is: {0}\n", result);
    }

    static void LinearEquation()
    {
        double firstCoefficient;

        do
        {
            Console.Write("a = ");
            firstCoefficient = double.Parse(Console.ReadLine());

            if (firstCoefficient == 0)
            {
                Console.Clear();
                Console.WriteLine("a should not be equal to 0.\n");
            }
        } while (firstCoefficient == 0);

        Console.Write("b = ");
        double secondCoefficient = double.Parse(Console.ReadLine());

        double result = -secondCoefficient / firstCoefficient;

        Console.WriteLine("x = {0}\n", result);
    }
}