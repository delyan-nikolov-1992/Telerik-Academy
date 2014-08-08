namespace GeometryAPI
{
    using System;

    public class Cylinder : Figure, ITransformable, IAreaMeasurable, IVolumeMeasurable
    {
        private double radius;
        private double height;

        public Cylinder(Vector3D a, Vector3D b, double radius)
            : base(a, b)
        {
            this.Radius = radius;
            this.Height = (this.A - this.B).Magnitude;
        }

        public double Radius
        {
            get { return this.radius; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The radius of the circle must be positive!");
                }

                this.radius = value;
            }
        }

        public double Height
        {
            get { return this.height; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The height of the cylinder must be positive!");
                }

                this.height = value;
            }
        }

        public Vector3D A
        {
            get { return this.vertices[0]; }
            set { this.vertices[0] = value; }
        }

        public Vector3D B
        {
            get { return this.vertices[1]; }
            set { this.vertices[1] = value; }
        }

        public double GetArea()
        {
            return (2 * Math.PI * this.Radius * this.Radius) + (2 * Math.PI * this.Radius * this.Height);
        }

        public double GetVolume()
        {
            return Math.PI * this.Radius * this.Radius * this.Height;
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetVolume();
        }
    }
}