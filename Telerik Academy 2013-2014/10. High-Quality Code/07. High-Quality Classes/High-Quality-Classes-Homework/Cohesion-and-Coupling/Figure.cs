namespace CohesionAndCoupling
{
    using System;

    public class Figure
    {
        private double width;
        private double height;
        private double depth;

        public Figure(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The width of the figure should be positive!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The height of the figure should be positive!");
                }

                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The depth of the figure should be positive!");
                }

                this.depth = value;
            }
        }

        public double CalcVolume()
        {
            double volume = this.width * this.height * this.depth;

            return volume;
        }

        public double CalcDiagonalXYZ()
        {
            double distance = MathUtils.CalcDistance3D(0, 0, 0, this.width, this.height, this.depth);

            return distance;
        }

        public double CalcDiagonalXY()
        {
            double distance = MathUtils.CalcDistance2D(0, 0, this.width, this.height);

            return distance;
        }

        public double CalcDiagonalXZ()
        {
            double distance = MathUtils.CalcDistance2D(0, 0, this.width, this.depth);

            return distance;
        }

        public double CalcDiagonalYZ()
        {
            double distance = MathUtils.CalcDistance2D(0, 0, this.height, this.depth);

            return distance;
        }
    }
}