using System;

class AddPolynomials
{
    static void Main()
    {
        try
        {
            Console.Write("The size of the first polynomial: ");
            int firstSize = int.Parse(Console.ReadLine());
            Console.Write("The size of the second polynomial: ");
            int secondSize = int.Parse(Console.ReadLine());

            if (firstSize >= 0 && secondSize >= 0)
            {
                double[] firstPolynomial = new double[firstSize];

                for (int i = 0; i < firstSize; i++)
                {
                    Console.Write("firstPolynomial[{0}] = ", i);
                    firstPolynomial[i] = double.Parse(Console.ReadLine());
                }

                double[] secondPolynomial = new double[secondSize];

                for (int i = 0; i < secondSize; i++)
                {
                    Console.Write("secondPolynomial[{0}] = ", i);
                    secondPolynomial[i] = double.Parse(Console.ReadLine());
                }

                double[] result = Add(firstPolynomial, secondPolynomial);

                //printing the polynomials
                Console.WriteLine();
                PrintPolynomial(firstPolynomial);
                Console.WriteLine("+");
                PrintPolynomial(secondPolynomial);
                Console.WriteLine("=");
                PrintPolynomial(result);
            }
            else
            {
                Console.WriteLine("The size of the polynomials must be greater than or equal to 0.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static double[] Add(double[] firstPolynomial, double[] secondPolynomial)
    {
        double[] result;
        int smallerLength;
        double[] biggerPolynomial;

        if (firstPolynomial.Length >= secondPolynomial.Length)
        {
            result = new double[firstPolynomial.Length];
            smallerLength = secondPolynomial.Length;
            biggerPolynomial = (double[])firstPolynomial.Clone();
        }
        else
        {
            result = new double[secondPolynomial.Length];
            smallerLength = firstPolynomial.Length;
            biggerPolynomial = (double[])secondPolynomial.Clone();
        }

        for (int i = 0; i < smallerLength; i++)
        {
            result[i] = firstPolynomial[i] + secondPolynomial[i];
        }

        for (int i = smallerLength; i < result.Length; i++)
        {
            result[i] = biggerPolynomial[i];
        }

        return result;
    }

    static void PrintPolynomial(double[] polynomial)
    {
        for (int i = polynomial.Length - 1; i >= 2; i--)
        {
            if (polynomial[i - 1] < 0)
            {
                Console.Write("{0}x^{1}", polynomial[i], i);
            }
            else
            {
                Console.Write("{0}x^{1}+", polynomial[i], i);
            }
        }

        if (polynomial[0] < 0)
        {
            Console.Write("{0}x{1}", polynomial[1], polynomial[0]);
        }
        else
        {
            Console.Write("{0}x+{1}", polynomial[1], polynomial[0]);
        }

        Console.WriteLine();
    }
}