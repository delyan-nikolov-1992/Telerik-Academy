namespace MobilePhone
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GSM
    {
        private static readonly GSM iPhone4S = 
            new GSM("iPhone 4S", "Apple Inc.", 999.99f, "Stefan Petrov", "A1387", 200, 8, BatteryType.LiIon, 9, 16000000);

        private string model;
        private string manufacturer;
        private float? price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory;

        // constructors
        public GSM(string model, string manufacturer, float? price, string owner, string batteriesModel, uint? hoursIdle,
            uint? hoursTalk, BatteryType? batteryType, float? size, uint? numberOfColors)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = new Battery(batteriesModel, hoursIdle, hoursTalk, batteryType);
            this.Display = new Display(size, numberOfColors);
            this.callHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, string batteriesModel)
            : this(model, manufacturer, null, null, batteriesModel, null, null, null, null, null)
        {

        }

        public GSM(string model, string manufacturer, float? price, string batteriesModel)
            : this(model, manufacturer, price, null, batteriesModel, null, null, null, null, null)
        {

        }

        public GSM(string model, string manufacturer, float? price, string owner, string batteriesModel)
            : this(model, manufacturer, price, owner, batteriesModel, null, null, null, null, null)
        {

        }

        public GSM(string model, string manufacturer, float? price, string owner, string batteriesModel, uint? hoursIdle)
            : this(model, manufacturer, price, owner, batteriesModel, hoursIdle, null, null, null, null)
        {

        }

        public GSM(string model, string manufacturer, float? price, string owner, string batteriesModel, uint? hoursIdle,
            uint? hoursTalk)
            : this(model, manufacturer, price, owner, batteriesModel, hoursIdle, hoursTalk, null, null, null)
        {

        }

        public GSM(string model, string manufacturer, float? price, string owner, string batteriesModel, uint? hoursIdle,
            uint? hoursTalk, BatteryType batteryType)
            : this(model, manufacturer, price, owner, batteriesModel, hoursIdle, hoursTalk, batteryType, null, null)
        {

        }

        public GSM(string model, string manufacturer, float? price, string owner, string batteriesModel, uint? hoursIdle,
            uint? hoursTalk, BatteryType batteryType, float? size)
            : this(model, manufacturer, price, owner, batteriesModel, hoursIdle, hoursTalk, batteryType, size, null)
        {

        }

        // properties
        public static GSM IPhone4S
        {
            get { return iPhone4S; }
        }

        public string Model
        {
            get { return this.model; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The GSM must have a model!");
                }

                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The GSM must have a manufacturer!");
                }

                this.manufacturer = value;
            }
        }

        public float? Price
        {
            get { return this.price; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The price of the GSM must be positive!");
                }

                this.price = value;
            }
        }

        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public Battery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        public Display Display
        {
            get { return this.display; }
            set { this.display = value; }
        }

        public List<Call> CallHistory
        {
            get { return this.callHistory; }
            set { this.callHistory = value; }
        }

        // methods
        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }

        private void DeleteCall(Call call)
        {
            this.callHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public void DeleteLongestCall()
        {
            Call longestCall = callHistory[0];

            for (int i = 1; i < callHistory.Count; i++)
            {
                if (longestCall.Duration < callHistory[i].Duration)
                {
                    longestCall = callHistory[i];
                }
            }

            DeleteCall(longestCall);
        }

        public float CallsPrice(float pricePerMinute)
        {
            float result = 0;

            foreach (Call currentCall in callHistory)
            {
                result += ((currentCall.Duration / 60) * pricePerMinute);

                // checks, whether the new minute has begun, because for example, 01:01 is taxed for two minutes, not for one
                if (currentCall.Duration - (60 * (currentCall.Duration / 60)) > 0)
                {
                    result += pricePerMinute;
                }
            }

            return result;
        }

        // string representation of this object
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("GSM:");
            result.AppendLine("Model: " + this.model);
            result.AppendLine("Manufacturer: " + this.manufacturer);
            result.AppendLine("Price: " + (this.price == null ? "unknown" : (this.price.ToString() + (" leva"))));
            result.AppendLine("Owner: " + (this.owner == null ? "unknown" : this.owner));
            result.Append(this.battery.ToString());
            result.Append(this.display.ToString());

            return result.ToString();
        }
    }
}