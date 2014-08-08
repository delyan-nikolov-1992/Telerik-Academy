namespace RangeException
{
    using System;

    public class Shell
    {
        static void Main()
        {
            try
            {
                int start = 1;
                int end = 100;
                int value = 200;

                if (value < start || value > end)
                {
                    throw new InvalidRangeException<int>(start, end);
                }
            }
            catch (InvalidRangeException<int> exc)
            {
                Console.WriteLine(exc.Message);
                Console.WriteLine("Start: {0}; End: {1};", exc.Start, exc.End);
            }

            Console.WriteLine();

            try
            {
                DateTime start = new DateTime(1980, 1, 1);
                DateTime end = new DateTime(2013, 12, 31);
                DateTime value = new DateTime(1970, 1, 1);

                if (value < start || value > end)
                {
                    throw new InvalidRangeException<DateTime>(start, end);
                }
            }
            catch (InvalidRangeException<DateTime> exc)
            {
                Console.WriteLine(exc.Message);
                Console.WriteLine("Start: {0}; End: {1};", exc.Start, exc.End);
            }
        }
    }
}