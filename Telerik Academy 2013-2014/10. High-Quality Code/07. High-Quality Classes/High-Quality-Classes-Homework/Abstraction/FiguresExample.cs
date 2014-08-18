namespace Abstraction
{
    using System;

    public class FiguresExample
    {
        public static void Main()
        {
            Figure circle = new Circle(5);
            Console.WriteLine(circle.ToString());

            Figure rect = new Rectangle(2, 3);
            Console.WriteLine(rect.ToString());
        }
    }
}