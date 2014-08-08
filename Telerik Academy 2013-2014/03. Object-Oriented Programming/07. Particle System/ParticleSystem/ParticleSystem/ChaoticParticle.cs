namespace ParticleSystem
{
    using System;

    public class ChaoticParticle : Particle
    {
        public ChaoticParticle(MatrixCoords position, MatrixCoords speed, Random random, int minRandomRange, int maxRandomRange)
            : base(position, speed)
        {
            this.Random = random;
            this.MinRandomRange = minRandomRange;
            this.MaxRandomRange = maxRandomRange;
        }

        public Random Random { get; private set; }

        public int MinRandomRange { get; private set; }

        public int MaxRandomRange { get; private set; }

        protected override void Move()
        {
            this.Speed = new MatrixCoords(this.Random.Next(this.MinRandomRange, this.MaxRandomRange),
                                          this.Random.Next(this.MinRandomRange, this.MaxRandomRange));

            this.Position += this.Speed;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { '#' } };
        }
    }
}