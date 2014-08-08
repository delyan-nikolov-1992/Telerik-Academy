namespace Point3D
{
    using System;
    using System.IO;

    public static class PathStorage
    {
        public static void SavePath(Path path)
        {
            using (StreamWriter writer = new StreamWriter("../../Output.txt"))
            {
                writer.Write(path.ToString());
                Console.WriteLine("\nThe new path was saved successfuly!");
            }
        }

        public static Path LoadPath()
        {
            Path loadedPath = new Path();

            using (StreamReader reader = new StreamReader("../../Input.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] splittedLine = line.Split(new char[] { ' ', '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    loadedPath.AddPoint(new Point3D(double.Parse(splittedLine[0]), double.Parse(splittedLine[1]), 
                                                    double.Parse(splittedLine[2])));
                    line = reader.ReadLine();
                }

                return loadedPath;
            }
        }
    }
}