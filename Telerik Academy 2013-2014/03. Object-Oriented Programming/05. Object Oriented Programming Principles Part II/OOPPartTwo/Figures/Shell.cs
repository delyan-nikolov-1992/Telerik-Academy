namespace Figures
{
    using System;

    public class Shell
    {
        public static void Main()
        {
            try
            {
                Shape[] shapes = new Shape[]
                {
                    new Circle(4.5),
                    new Rectangle(3.2, 9.1),
                    new Triangle(1.8, 5.4)
                };

                foreach (var currentShape in shapes)
                {
                    Console.WriteLine("{0}'s surface is {1}", currentShape.GetType().Name, currentShape.CalculateSurface());
                }
            }
            catch (ArgumentOutOfRangeException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}