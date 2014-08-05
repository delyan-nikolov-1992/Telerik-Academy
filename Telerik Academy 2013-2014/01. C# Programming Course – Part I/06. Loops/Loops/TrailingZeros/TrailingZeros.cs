using System;

class TrailingZeros
{
    static void Main()
    {
        try
        {
            Console.Write("N = ");
            int number = int.Parse(Console.ReadLine());

            if (number >= 0)
            {
                int counter = 0;

                for (int i = 5; i <= number; i += 5)
                {
                    counter++;
                }

                Console.WriteLine("The trailing zeros are " + counter);
            }
            else
            {
                Console.WriteLine("N must be greater than or equal to 0.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}