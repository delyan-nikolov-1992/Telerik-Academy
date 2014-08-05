using System;

class SurfaceOfTriangle
{
    static void Main()
    {
        try
        {
            //defines the side and an altitude to it
            Console.Write("The side of the triangle: ");
            double side = double.Parse(Console.ReadLine());
            Console.Write("The altitude to the side: ");
            double altitude = double.Parse(Console.ReadLine());

            if (side > 0 && altitude > 0)
            {
                //calculates the surface by given side and an altitude to it
                double result = SurfaceByGivenSideAndAltitude(side, altitude);
                Console.WriteLine("The surface of the triangle is {0}\n", result);

                //defines the three sides
                Console.Write("The first side of the triangle: ");
                double firstSide = double.Parse(Console.ReadLine());
                Console.Write("The second side of the triangle: ");
                double secondSide = double.Parse(Console.ReadLine());
                Console.Write("The third side of the triangle: ");
                double thirdSide = double.Parse(Console.ReadLine());

                if (firstSide > 0 && secondSide > 0 && thirdSide > 0)
                {
                    //calculates the surface by given three sides
                    result = SurfaceByGivenThreeSides(firstSide, secondSide, thirdSide);
                    Console.WriteLine("The surface of the triangle is {0}\n", result);

                    //defines the two sides and an angle between them
                    Console.Write("The first side of the triangle: ");
                    firstSide = double.Parse(Console.ReadLine());
                    Console.Write("The second side of the triangle: ");
                    secondSide = double.Parse(Console.ReadLine());
                    Console.Write("The angle between the two sides: ");
                    double angle = double.Parse(Console.ReadLine());

                    if (firstSide > 0 && secondSide > 0 && angle > 0 && angle < 180)
                    {
                        //calculates the surface by given two sides and an angle between them
                        result = SurfaceByGivenTwoSidesAndAngle(firstSide, secondSide, angle);
                        Console.WriteLine("The surface of the triangle is {0}", result);
                    }
                    else
                    {
                        Console.WriteLine("The two sides of the triangle must be greater than 0 and the angle between them must be in the range (0; 180).");
                    }
                }
                else
                {
                    Console.WriteLine("The three sides of the triangle must be greater than 0.");
                }
            }
            else
            {
                Console.WriteLine("The side and the altitude of the triangle must be greater than 0.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static double SurfaceByGivenSideAndAltitude(double side, double altitude)
    {
        double result = (side * altitude) / 2;

        return result;
    }

    static double SurfaceByGivenThreeSides(double firstSide, double secondSide, double thirdSide)
    {
        double semiperimeter = (firstSide + secondSide + thirdSide) / 2;
        double result = Math.Sqrt(semiperimeter * (semiperimeter - firstSide) * (semiperimeter - secondSide) * (semiperimeter - thirdSide));

        return result;
    }

    static double SurfaceByGivenTwoSidesAndAngle(double firstSide, double secondSide, double angle)
    {
        double angleInRad = (Math.PI / 180) * angle;
        double result = (firstSide * secondSide * Math.Sin(angleInRad)) / 2;

        return result;
    }
}