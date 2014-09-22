namespace SortingHomework
{
    using System;

    public class RandomProvider : IRandomProvider
    {
        private static IRandomProvider randomProvider;

        private Random random;

        private RandomProvider()
        {
            this.random = new Random();
        }

        public static IRandomProvider Instance
        {
            get
            {
                if (randomProvider == null)
                {
                    randomProvider = new RandomProvider();
                }

                return randomProvider;
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max);
        }
    }
}