using System;

class QuadraticEquation
{
    static void Main()
    {
        try
        {
            Console.Write("a = ");
            double firstCoefficient = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double secondCoefficient = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            double thirdCoefficient = double.Parse(Console.ReadLine());

            if (firstCoefficient == 0)
            {
                Console.WriteLine("The equation is not quadratic.");
            }
            else
            {
                double discriminant = (secondCoefficient * secondCoefficient)
                                        - (4 * firstCoefficient * thirdCoefficient);

                if (discriminant < 0)
                {
                    Console.WriteLine("There are no real roots.");
                }
                else
                {
                    double firstRoot = (-secondCoefficient + Math.Sqrt(discriminant)) / (2 * firstCoefficient);
                    double secondRoot = (-secondCoefficient - Math.Sqrt(discriminant)) / (2 * firstCoefficient);

                    if (discriminant > 0)
                    {
                        Console.WriteLine("The two real roots are " + firstRoot + " and " + secondRoot);
                    }
                    else
                    {
                        Console.WriteLine("There is exactly one real root: " + firstRoot);
                    }
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}