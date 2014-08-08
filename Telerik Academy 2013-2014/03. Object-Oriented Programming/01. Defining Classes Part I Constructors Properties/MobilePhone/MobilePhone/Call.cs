namespace MobilePhone
{
    using System;
    using System.Text;

    public class Call
    {
        private DateTime date;
        private string dialedPhoneNumber;
        private uint duration;

        // constructor
        public Call(DateTime date, string dialedPhoneNumber, uint duration)
        {
            this.Date = date;
            this.DialedPhoneNumber = dialedPhoneNumber;
            this.Duration = duration;
        }

        // properties
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        public string DialedPhoneNumber
        {
            get { return this.dialedPhoneNumber; }
            set { this.dialedPhoneNumber = value; }
        }

        public uint Duration
        {
            get { return this.duration; }
            set { this.duration = value; }
        }

        // string representation of this object
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Call:");
            result.AppendLine("Date: " + this.date.ToString());
            result.AppendLine("Dialed Phone Number: " + this.dialedPhoneNumber.ToString());
            result.AppendLine("Duration: " + this.duration.ToString() + " s.");

            return result.ToString();
        }
    }
}