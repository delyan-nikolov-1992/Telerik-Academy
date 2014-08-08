namespace GeometryAPI
{
    using System;

    public class Circle : Figure, ITransformable, IAreaMeasurable, IFlat
    {
        private double radius;

        public Circle(Vector3D center, double radius)
            : base(center)
        {
            this.Radius = radius;
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

        public Vector3D Center
        {
            get { return this.vertices[0]; }
            set { this.vertices[0] = value; }
        }

        public double GetArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public Vector3D GetNormal()
        {
            Vector3D A = new Vector3D(this.Center.X + this.Radius, this.Center.Y, this.Center.Z);
            Vector3D B = new Vector3D(this.Center.X, this.Center.Y + this.Radius, this.Center.Z);

            Vector3D normal = Vector3D.CrossProduct(this.Center - A, this.Center - B);

            normal.Normalize();

            return normal;
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetArea();
        }
    }
}