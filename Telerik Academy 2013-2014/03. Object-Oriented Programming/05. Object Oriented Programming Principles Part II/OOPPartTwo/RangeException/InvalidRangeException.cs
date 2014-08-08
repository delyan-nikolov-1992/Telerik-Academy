namespace RangeException
{
    using System;

    public class InvalidRangeException<T> : Exception
    {
        private const string MESSAGE = "Out of range!";
        private T start;
        private T end;

        public InvalidRangeException(T start, T end)
            : base(MESSAGE, null)
        {
            this.Start = start;
            this.End = end;
        }

        public T Start
        {
            get { return this.start; }
            set { this.start = value; }
        }

        public T End
        {
            get { return this.end; }
            set { this.end = value; }
        }
    }
}