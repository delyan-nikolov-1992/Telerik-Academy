namespace Methods
{
    using System;

    public class Methods
    {
        public static double CalcTriangleArea(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide <= 0 || secondSide <= 0 || thirdSide <= 0)
            {
                throw new ArgumentOutOfRangeException("All sides of the triangle should be positive!");
            }

            double semiperimeter = (firstSide + secondSide + thirdSide) / 2;
            double area = Math.Sqrt(semiperimeter * (semiperimeter - firstSide) *
                                   (semiperimeter - secondSide) * (semiperimeter - thirdSide));

            return area;
        }

        public static string PrintDigit(byte digit)
        {
            switch (digit)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return "Invalid digit!";
            }
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("The array of elements should not be null!");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentOutOfRangeException("The array of elements should not be empty!");
            }

            int max = int.MinValue;

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        public static void PrintAsNumber(object number, string format)
        {
            if (format == "Fixed-point")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "Percent")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "Round-trip")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                Console.WriteLine("There is no such format!");
            }
        }

        public static double CalcDistance(
                                          double firstXCoord,
                                          double firstYCoord,
                                          double secondXCoord,
                                          double secondYCoord,
                                          out bool isHorizontal,
                                          out bool isVertical)
        {
            double distance = Math.Sqrt(((secondXCoord - firstXCoord) * (secondXCoord - firstXCoord)) +
                                        ((secondYCoord - firstYCoord) * (secondYCoord - firstYCoord)));

            isHorizontal = firstYCoord == secondYCoord;
            isVertical = firstXCoord == secondXCoord;

            return distance;
        }

        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(PrintDigit(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "Fixed-point");
            PrintAsNumber(0.75, "Percent");
            PrintAsNumber(2.30, "Round-trip");

            bool horizontal;
            bool vertical;

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student()
            {
                FirstName = "Peter",
                LastName = "Ivanov",
                City = "Sofia",
                DateOfBirth = new DateTime(1992, 03, 17)
            };

            Student stella = new Student()
            {
                FirstName = "Stella",
                LastName = "Markova",
                City = "Vidin",
                DateOfBirth = new DateTime(1993, 11, 03)
            };

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}