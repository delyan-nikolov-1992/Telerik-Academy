namespace Point3D
{
    using System;

    public static class Distance
    {
        public static double CalculateDistance(Point3D firstPoint, Point3D secondPoint)
        {
            double xCoordDifference = firstPoint.XCoord - secondPoint.XCoord;
            double yCoordDifference = firstPoint.YCoord - secondPoint.YCoord;
            double zCoordDifference = firstPoint.ZCoord - secondPoint.ZCoord;
            double result = Math.Sqrt((xCoordDifference * xCoordDifference) + (yCoordDifference * yCoordDifference)
                                        + (zCoordDifference * zCoordDifference));

            return result;
        }
    }
}