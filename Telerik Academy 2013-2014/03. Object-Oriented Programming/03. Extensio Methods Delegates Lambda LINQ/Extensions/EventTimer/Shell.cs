// Task 08

namespace EventTimer
{
    using System;
    using System.Threading;

    public class Shell
    {
        static void Main()
        {
            Timer timer = new Timer();
            timer.TimeElapsed += new Ticker(timer.TickerProcess);


            // counting 10 seconds
            while (timer.Seconds < 10)
            {
                timer.Subscribe(1);
                Thread.Sleep(1000);
                Console.WriteLine(timer.Seconds);
            }
        }
    }
}