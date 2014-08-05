using System;

class AmericanPie
{
    static void Main()
    {
        decimal a = decimal.Parse(Console.ReadLine());
        decimal b = decimal.Parse(Console.ReadLine());
        decimal c = decimal.Parse(Console.ReadLine());
        decimal d = decimal.Parse(Console.ReadLine());

        decimal result = (a / b) + (c / d);
        long top = ((long)(a) * (long)(d)) + ((long)(c) * (long)(b));
        long bottom = (long)(b) * (long)(d);

        if (result < 1)
        {
            Console.WriteLine("{0:F20}", result);

        }
        else
        {
            long summary = (long)result;
            Console.WriteLine(summary);
        }


        if (bottom == 1)
        {
            Console.WriteLine(top);
        }
        else
        {
            Console.WriteLine(top + "/" + bottom);
        }


    }
}