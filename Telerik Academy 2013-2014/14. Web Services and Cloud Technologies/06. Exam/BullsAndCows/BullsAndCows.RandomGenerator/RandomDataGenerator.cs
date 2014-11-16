namespace BullsAndCows.RandomGenerator
{
    using System;

    public class RandomDataGenerator : IRandomDataGenerator
    {
        private static IRandomDataGenerator randomDataGenerator;
        private Random random;

        private RandomDataGenerator()
        {
            this.random = new Random();
        }

        public static IRandomDataGenerator Instance
        {
            get
            {
                if (randomDataGenerator == null)
                {
                    randomDataGenerator = new RandomDataGenerator();
                }

                return randomDataGenerator;
            }
        }

        public int GetRandomInt(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }
    }
}