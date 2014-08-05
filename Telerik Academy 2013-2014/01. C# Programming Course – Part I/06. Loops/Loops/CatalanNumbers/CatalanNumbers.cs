using System;

class CatalanNumbers
{
    static void Main()
    {
        try
        {
            Console.Write("N = ");
            int number = int.Parse(Console.ReadLine());

            if (number >= 0)
            {
                decimal firstFactorial = 1;
                decimal secondFactorial = 2;
                decimal thirdFactorial = 1;
                decimal result = 1;

                for (int i = 2; i <= number * 2; i++)
                {
                    firstFactorial *= i;
                }

                for (int i = 2; i <= number; i++)
                {
                    secondFactorial *= (i + 1);
                    thirdFactorial *= i;
                }

                if (number > 1)
                {
                    result = firstFactorial / (secondFactorial * thirdFactorial);
                }

                Console.WriteLine("The " + number + ". Catalan number is " + result);
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