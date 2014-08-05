using System;

class PrintSpiral
{
    static void Main()
    {
        try
        {
            Console.Write("N = ");
            int number = int.Parse(Console.ReadLine());

            if (number > 0 && number < 20)
            {
                int[,] result = new int[number, number];
                int position = 1;
                int counter = number;
                int value = -number;
                int sum = -1;

                do
                {
                    value = -1 * value / number;

                    for (int i = 0; i < counter; i++)
                    {
                        sum += value;
                        result[sum / number, sum % number] = position++;
                    }

                    value *= number;
                    counter--;

                    for (int i = 0; i < counter; i++)
                    {
                        sum += value;
                        result[sum / number, sum % number] = position++;
                    }
                } while (counter > 0);

                number = (result.GetLength(0) * result.GetLength(1)).ToString().Length + 1;

                for (int i = 0; i < result.GetLength(0); i++)
                {
                    for (int j = 0; j < result.GetLength(1); j++)
                    {
                        Console.Write(result[i, j].ToString().PadRight(number, ' '));
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("N must be in the intervall (0;20).");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}