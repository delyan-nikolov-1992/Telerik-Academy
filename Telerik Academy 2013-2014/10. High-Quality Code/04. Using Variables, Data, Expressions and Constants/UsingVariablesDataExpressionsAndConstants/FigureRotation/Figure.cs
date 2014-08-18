namespace FigureRotation
{
    using System;

    public class Figure
    {
        private double width;
        private double height;

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The width of the figure must be positive!");
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

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The height of the figure must be positive!");
                }

                this.height = value;
            }
        }

        public static Figure GetRotatedFigure(Figure figure, double rotationAngle)
        {
            double sinOfRotationAngle = Math.Abs(Math.Sin(rotationAngle));
            double cosOfRotationAngle = Math.Abs(Math.Cos(rotationAngle));
            double rotatedWidth = (cosOfRotationAngle * figure.width) + (sinOfRotationAngle * figure.height);
            double rotatedHeight = (sinOfRotationAngle * figure.width) + (cosOfRotationAngle * figure.height);
            Figure rotatedFigure = new Figure(rotatedWidth, rotatedHeight);

            return rotatedFigure;
        }
    }
}