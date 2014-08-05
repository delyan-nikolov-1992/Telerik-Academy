using System;

class ApplesOrOranges
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        long odd = 0;
        long even = 0;
        long current;

        if (number < 0)
        {

            number *= -1;
        }



        while (number > 0)
        {


            current = number % 10;
            number /= 10;

            if (current % 2 == 0)
            {
                even += current;
            }
            else
            {
                odd += current;
            }

        }

        if (even > odd)
        {
            Console.WriteLine("apples " + even);
        }
        else if (even < odd)
        {
            Console.WriteLine("oranges " + odd);
        }
        else
        {
            Console.WriteLine("both " + even);
        }
    }
}