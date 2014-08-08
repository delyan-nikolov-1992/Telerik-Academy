// Task 07

namespace DelegatesTimer
{
    using System;
    using System.Threading;

    public class Shell
    {
        public static void Main()
        {
            Timer timer = new Timer();
            Ticker ticker = new Ticker(timer.TickerProcess);

            // counting 10 seconds
            while (timer.Seconds < 10)
            {
                ticker(1);
                Thread.Sleep(1000);
                Console.WriteLine(timer.Seconds);
            }
        }
    }
}