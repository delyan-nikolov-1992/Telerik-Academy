namespace DelegatesTimer
{
    public delegate void Ticker(int counter);

    public class Timer
    {
        public int Seconds { get; set; }

        public void TickerProcess(int counter)
        {
            this.Seconds += counter;
        }
    }
}