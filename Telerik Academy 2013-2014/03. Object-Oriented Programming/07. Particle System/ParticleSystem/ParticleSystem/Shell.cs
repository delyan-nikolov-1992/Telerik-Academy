namespace ParticleSystem
{
    using System;

    public class Shell
    {
        private const int Rows = 60;
        private const int Cols = 40;
        private const int MinRandomRange = 1;
        private const int MaxRandomRange = 6;
        private const int Delay = 2;
        private const int AttractionPower = 3;
        private const int Radius = 3;

        private static readonly Random RandomGenerator = new Random();

        public static void Main()
        {
            var renderer = new ConsoleRenderer(Rows, Cols);
            var particleOperator = new OppositeParticleOperator();
            var engine = new Engine(renderer, particleOperator, null, 500);

            GenerateInitialData(engine);

            engine.Run();
        }

        private static void GenerateInitialData(Engine engine)
        {
            engine.AddParticle(
                new ChaoticParticle(
                    new MatrixCoords(0, 8),
                    new MatrixCoords(-1, 0),
                    RandomGenerator,
                    MinRandomRange,
                    MaxRandomRange));

            engine.AddParticle(
                new ChaoticParticle(
                    new MatrixCoords(10, 10),
                    new MatrixCoords(-1, 0),
                    RandomGenerator,
                    MinRandomRange,
                    MaxRandomRange));

            engine.AddParticle(
                new ChickenParticle(
                    new MatrixCoords(20, 5),
                    new MatrixCoords(-1, 1),
                    RandomGenerator,
                    MinRandomRange,
                    MaxRandomRange,
                    Delay));

            engine.AddParticle(
                new ParticleRepeller(
                    new MatrixCoords(10, 3),
                    new MatrixCoords(0, 0),
                    AttractionPower,
                    Radius));

            engine.AddParticle(
                new ParticleRepeller(
                    new MatrixCoords(10, 13),
                    new MatrixCoords(0, 0),
                    AttractionPower,
                    Radius));

            engine.AddParticle(
                new ParticleRepeller(
                    new MatrixCoords(30, 15),
                    new MatrixCoords(0, 0),
                    AttractionPower,
                    Radius));

            engine.AddParticle(
                new ParticleRepeller(
                    new MatrixCoords(30, 25),
                    new MatrixCoords(0, 0),
                    AttractionPower,
                    Radius));
        }
    }
}