namespace ParticleSystem
{
    public class ParticleRepeller : Particle
    {
        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int attractionPower, int radius) :
            base(position, speed)
        {
            this.Power = attractionPower;
            this.Radius = radius;
        }

        public int Power { get; private set; }

        public int Radius { get; private set; }

        public override char[,] GetImage()
        {
            return new char[,] { { '0' } };
        }
    }
}