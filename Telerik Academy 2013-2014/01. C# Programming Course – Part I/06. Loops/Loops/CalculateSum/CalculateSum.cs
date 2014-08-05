using System;

class CalculateSum
{
    static void Main()
    {
        try
        {
            Console.Write("N = ");
            int firstNumber = int.Parse(Console.ReadLine());

            if (firstNumber >= 0)
            {
                Console.Write("X = ");
                int secondNumber = int.Parse(Console.ReadLine());

                if (secondNumber != 0)
                {
                    int factorial = 1;
                    int power = secondNumber;
                    double result = 1;

                    if (firstNumber != 0)
                    {
                        result += (double)factorial / power;

                        for (int i = 2; i <= firstNumber; i++)
                        {
                            factorial *= i;
                            power *= secondNumber;
                            result += (double)factorial / power;
                        }
                    }

                    Console.WriteLine("S = " + result);
                }
                else
                {
                    Console.WriteLine("X must not be equal to 0.");
                }
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