namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    public class ChickenParticle : ChaoticParticle
    {
        private const int MinRandomStop = 1;
        private const int MaxRandomStop = 6;
        private const int RandomStopper = 3;

        private readonly int delay;

        private int delayCounter;
        private bool layEgg;

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, Random randomGen, int minRandomRange, int maxRandomRange,
            int delay)
            : base(position, speed, randomGen, minRandomRange, maxRandomRange)
        {
            this.delay = delay;
        }

        public override IEnumerable<Particle> Update()
        {
            if (this.layEgg == true)
            {
                this.delayCounter++;

                if (delayCounter == delay)
                {
                    this.delayCounter = 0;
                    layEgg = false;

                    return this.LayEgg();
                }

                return new List<Particle>();
            }

            if (RandomStopper == this.Random.Next(MinRandomStop, MaxRandomStop))
            {
                this.layEgg = true;
            }

            return base.Update();
        }

        public IEnumerable<Particle> LayEgg()
        {
            return new List<Particle>() 
            { 
                new ChickenParticle(this.Position, this.Speed, this.Random, this.MinRandomRange, this.MaxRandomRange, this.delay) 
            };
        }

        public override char[,] GetImage()
        {
            return new char[,] { { '@' } };
        }
    }
}