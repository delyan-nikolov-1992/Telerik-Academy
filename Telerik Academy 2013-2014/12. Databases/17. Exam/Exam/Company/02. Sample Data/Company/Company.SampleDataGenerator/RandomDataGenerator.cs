namespace Company.SampleDataGenerator
{
    using System;

    internal class RandomDataGenerator : IRandomDataGenerator
    {
        private const string Letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

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

        public double GetRandomDouble(double minimum, double maximum)
        {
            return (this.random.NextDouble() * (maximum - minimum)) + minimum;
        }

        public string GetRandomString(int length)
        {
            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = Letters[this.GetRandomInt(0, Letters.Length - 1)];
            }

            return new string(result);
        }

        public string GetRandomStringWithRandomLength(int min, int max)
        {
            return this.GetRandomString(this.GetRandomInt(min, max));
        }

        public DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {
            var range = endDate - startDate;

            var randTimeSpan = new TimeSpan((long)(this.random.NextDouble() * range.Ticks));

            return startDate + randTimeSpan;
        }

        public bool GetChance(int percent)
        {
            return this.GetRandomInt(0, 100) <= percent;
        }
    }
}