namespace Company.SampleDataGenerator
{
    using System;

    internal interface IRandomDataGenerator
    {
        int GetRandomInt(int min, int max);

        double GetRandomDouble(double minimum, double maximum);

        string GetRandomString(int length);

        string GetRandomStringWithRandomLength(int min, int max);

        DateTime GetRandomDate(DateTime startDate, DateTime endDate);

        bool GetChance(int percent);
    }
}