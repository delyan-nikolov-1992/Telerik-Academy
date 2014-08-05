using System;

class CirclePerimeterAndArea
{
    static void Main()
    {
        try
        {
            Console.Write("The radius of the circle: ");
            double radius = double.Parse(Console.ReadLine());

            if (radius <= 0)
            {
                Console.WriteLine("The radius of the circle must be positive.");
            }
            else
            {
                double perimeter = 2 * Math.PI * radius;
                double area = Math.PI * radius * radius;

                Console.WriteLine("The perimeter of the circle is " + perimeter);
                Console.WriteLine("The area of the circle is " + area);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}