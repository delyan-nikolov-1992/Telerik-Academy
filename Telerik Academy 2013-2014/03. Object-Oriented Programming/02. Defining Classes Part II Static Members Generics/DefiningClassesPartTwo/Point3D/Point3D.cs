namespace Point3D
{
    public struct Point3D
    {
        private static readonly Point3D startintPoint = new Point3D(0, 0, 0);

        private double xCoord;
        private double yCoord;
        private double zCoord;

        public Point3D(double xCoord, double yCoord, double zCoord)
            : this()
        {
            this.XCoord = xCoord;
            this.YCoord = yCoord;
            this.ZCoord = zCoord;
        }

        public static Point3D StartingPoint
        {
            get { return startintPoint; }
        }

        public double XCoord
        {
            get { return this.xCoord; }
            set { this.xCoord = value; }
        }

        public double YCoord
        {
            get { return this.yCoord; }
            set { this.yCoord = value; }
        }

        public double ZCoord
        {
            get { return this.zCoord; }
            set { this.zCoord = value; }
        }

        public override string ToString()
        {
            return "(" + this.xCoord + ", " + +this.yCoord + ", " + +this.zCoord + ")";
        }
    }
}