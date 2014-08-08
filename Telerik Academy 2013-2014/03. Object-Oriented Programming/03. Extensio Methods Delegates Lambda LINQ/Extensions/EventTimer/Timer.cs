namespace EventTimer
{
    public delegate void Ticker(object publisher, int counter);

    public class Timer
    {
        public int Seconds { get; set; }

        public event Ticker TimeElapsed;

        public void Subscribe(int ticks)
        {
            TimeElapsed(this, ticks);
        }

        public void TickerProcess(object publisher, int counter)
        {
            this.Seconds += counter;
        }
    }
}