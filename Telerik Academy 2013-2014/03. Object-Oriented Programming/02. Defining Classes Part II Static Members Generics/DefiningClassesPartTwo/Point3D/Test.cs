namespace Point3D
{
    using System;
    using System.IO;

    public class Test
    {
        public static void Main()
        {
            try
            {
                Point3D currentPoint = new Point3D(-7, -4, 3.12);
                Console.WriteLine(currentPoint.ToString());

                Point3D startingPoint = Point3D.StartingPoint;
                Console.WriteLine(startingPoint.ToString());

                Console.WriteLine("\nThe distance between these two points is: {0}", Distance.CalculateDistance(currentPoint, startingPoint));

                Path savedPath = new Path();
                savedPath.AddPoint(currentPoint);
                savedPath.AddPoint(startingPoint);
                savedPath.AddPoint(new Point3D(4.3, -2.2, 6.25));
                PathStorage.SavePath(savedPath);

                Console.WriteLine("\nPrinting Loaded Path:");
                Path loadedPath = PathStorage.LoadPath();
                Console.Write(loadedPath.ToString());
            }
            catch (IOException)
            {
                Console.WriteLine("Input/Output error!");
            }
        }
    }
}