using System;

class PointWithinCircle
{
    static void Main()
    {
        try
        {
            Console.Write("The x coordinate of the point: ");
            double xCoord = double.Parse(Console.ReadLine());
            Console.Write("The y coordinate of the point: ");
            double yCoord = double.Parse(Console.ReadLine());

            if ((xCoord * xCoord + yCoord * yCoord) <= 25)
                Console.WriteLine("The given point is within the circle.");
            else
                Console.WriteLine("The given point is not within the circle.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }

    }
}