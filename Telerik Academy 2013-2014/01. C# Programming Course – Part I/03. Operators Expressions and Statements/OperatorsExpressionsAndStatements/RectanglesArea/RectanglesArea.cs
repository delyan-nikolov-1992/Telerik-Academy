using System;

class RectanglesArea
{
    static void Main()
    {
        try
        {
            Console.Write("The width of the rectangle: ");
            double width = double.Parse(Console.ReadLine());
            Console.Write("The height of the rectangle: ");
            double height = double.Parse(Console.ReadLine());
            double area;

            if (width > 0 && height > 0)
            {
                area = width * height;
                Console.WriteLine("The rectangle's area is " + area);
            }
            else
                Console.WriteLine("The width and the height of the rectangle must be positive numbers.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}