namespace MobilePhone
{
    using System;
    using System.Text;

    public class Battery
    {
        private string model;
        private uint? hoursIdle;
        private uint? hoursTalk;
        private BatteryType? batteryType;

        // constructors
        public Battery(string model, uint? hoursIdle, uint? hoursTalk, BatteryType? batteryType)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }

        public Battery(string model)
            : this(model, null, null, null)
        {

        }

        public Battery(string model, uint? hoursIdle)
            : this(model, hoursIdle, null, null)
        {

        }

        public Battery(string model, uint? hoursIdle, uint? hoursTalk)
            : this(model, hoursIdle, hoursTalk, null)
        {

        }

        // properties
        public string Model
        {
            get { return this.model; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The battery must have a model!");
                }

                this.model = value;
            }
        }

        public uint? HoursIdle
        {
            get { return this.hoursIdle; }
            set { this.hoursIdle = value; }
        }

        public uint? HoursTalk
        {
            get { return this.hoursTalk; }
            set { this.hoursTalk = value; }
        }

        public BatteryType? BatteryType
        {
            get { return this.batteryType; }
            set { this.batteryType = value; }
        }

        // string representation of this object
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Battery:");
            result.AppendLine("Model: " + this.model);
            result.AppendLine("Hours Idle: " + (this.hoursIdle == null ? "unknown" : this.hoursIdle.ToString()));
            result.AppendLine("Hours Talk: " + (this.hoursTalk == null ? "unknown" : this.hoursTalk.ToString()));
            result.AppendLine("Battery Type: " + (this.batteryType == null ? "unknown" : this.batteryType.ToString()));

            return result.ToString();
        }
    }
}