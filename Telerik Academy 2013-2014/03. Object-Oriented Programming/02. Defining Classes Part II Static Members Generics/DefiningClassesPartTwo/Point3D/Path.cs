namespace Point3D
{
    using System.Text;
    using System.Collections.Generic;

    public class Path
    {
        private List<Point3D> allPoints;

        public Path()
        {
            this.AllPoints = new List<Point3D>();
        }

        public List<Point3D> AllPoints
        {
            get { return this.allPoints; }
            set { this.allPoints = value; }
        }

        public void AddPoint(Point3D point)
        {
            this.allPoints.Add(point);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (Point3D currentPoint in allPoints)
            {
                result.AppendLine(currentPoint.ToString());
            }

            return result.ToString();
        }
    }
}