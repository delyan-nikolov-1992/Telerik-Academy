using System;

class TrapezoidsArea
{
    static void Main()
    {
        try
        {
            Console.Write("The first side of the trapezoid: ");
            double firstSide = double.Parse(Console.ReadLine());
            Console.Write("The second side of the trapezoid: ");
            double secondSide = double.Parse(Console.ReadLine());
            Console.Write("The height of the trapezoid: ");
            double height = double.Parse(Console.ReadLine());
            double area;

            if (firstSide > 0 && secondSide > 0 && height > 0)
            {
                area = ((firstSide + secondSide) / 2) * height;
                Console.WriteLine("The area of the trapezoid is " + area);
            }
            else
                Console.WriteLine("The two sides and the height of the trapezoid must be positive numbers.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}