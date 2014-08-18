namespace Abstraction
{
    public abstract class Figure
    {
        public Figure()
        {
        }

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();

        public override string ToString()
        {
            return string.Format("My perimeter is {0:f2}. My surface is {1:f2}.", this.CalcPerimeter(), this.CalcSurface());
        }
    }
}