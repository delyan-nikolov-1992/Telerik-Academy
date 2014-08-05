using System;

class SumOfNumbers
{
    static void Main()
    {
        try
        {
            Console.Write("n = ");
            int number = int.Parse(Console.ReadLine());

            if (number < 0)
            {
                Console.WriteLine("n must be greater than or equal to 0.");
            }
            else
            {
                int sum = number;
                int current;

                for (int i = 1; i <= number; i++)
                {
                    Console.Write(i + ". number = ");
                    current = int.Parse(Console.ReadLine());

                    sum += current;
                }

                Console.WriteLine("The sum is " + sum);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}