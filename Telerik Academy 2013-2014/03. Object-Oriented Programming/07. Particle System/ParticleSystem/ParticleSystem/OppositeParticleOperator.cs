namespace ParticleSystem
{
    using System;
    using System.Collections.Generic;

    // the same class as AdvanceParticleOperator but changes the currAcceleration to negative direction
    public class OppositeParticleOperator : ParticleUpdater
    {
        List<ParticleRepeller> repellers = new List<ParticleRepeller>();
        List<Particle> particles = new List<Particle>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var repelerCandidate = p as ParticleRepeller;

            if (repelerCandidate == null)
            {
                this.particles.Add(p);
            }
            else
            {
                this.repellers.Add(repelerCandidate);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var repeller in this.repellers)
            {
                foreach (var particle in this.particles)
                {
                    int radius = (int)Math.Sqrt((repeller.Position.Col - particle.Position.Col)
                                              * (repeller.Position.Col - particle.Position.Col)
                                              + (repeller.Position.Row - particle.Position.Row)
                                              * (repeller.Position.Row - particle.Position.Row));

                    if (radius <= repeller.Radius)
                    {
                        var currAcceleration = GetAccelerationFromParticleToRepeller(repeller, particle);

                        particle.Accelerate(currAcceleration);
                    }
                }
            }

            this.repellers.Clear();
            this.particles.Clear();
            base.TickEnded();
        }

        private static MatrixCoords GetAccelerationFromParticleToRepeller(ParticleRepeller repeller, Particle particle)
        {
            var currParticleToRepelerVector = repeller.Position - particle.Position;

            int pToRepRow = currParticleToRepelerVector.Row;
            pToRepRow = DecreaseVectorCoordToPower(repeller, pToRepRow);

            int pToRepCol = currParticleToRepelerVector.Col;
            pToRepCol = DecreaseVectorCoordToPower(repeller, pToRepCol);

            var currAcceleration = new MatrixCoords(-pToRepRow, -pToRepCol);

            return currAcceleration;
        }

        private static int DecreaseVectorCoordToPower(ParticleRepeller repeller, int pToRepCoord)
        {
            if (Math.Abs(pToRepCoord) > repeller.Power)
            {
                pToRepCoord = (pToRepCoord / (int)Math.Abs(pToRepCoord)) * repeller.Power;
            }

            return pToRepCoord;
        }
    }
}