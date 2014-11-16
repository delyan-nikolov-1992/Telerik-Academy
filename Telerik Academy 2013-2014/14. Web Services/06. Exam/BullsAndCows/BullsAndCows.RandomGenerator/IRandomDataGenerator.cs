namespace BullsAndCows.RandomGenerator
{
    using System;

    public interface IRandomDataGenerator
    {
        int GetRandomInt(int min, int max);
    }
}