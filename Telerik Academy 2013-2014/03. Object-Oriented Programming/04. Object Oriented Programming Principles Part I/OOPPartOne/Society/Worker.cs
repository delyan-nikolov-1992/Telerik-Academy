namespace Society
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private float weekSalary;
        private byte workHoursPerDay;

        public Worker(string firstName, string lastName, float weekSalary, byte workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public float WeekSalary
        {
            get { return this.weekSalary; }

            set
            {
                // the week salary must be positive
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The week salary of the worker must be positive!");
                }

                this.weekSalary = value;
            }
        }

        public byte WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }

            set
            {
                // one day have only 24 hours
                if (value > 24)
                {
                    throw new ArgumentOutOfRangeException("The work hours per day of the worker must be less than 24!");
                }

                this.workHoursPerDay = value;
            }
        }

        public float MoneyPerHour()
        {
            // if we assume that the workdays are 5 as in Bulgaria
            // always can change the value from here
            float result = weekSalary / (workHoursPerDay * 5);

            return result;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Worker:");
            result.AppendLine(base.ToString());
            result.AppendFormat("Money per hour: {0:C}\n", this.MoneyPerHour());

            return result.ToString();
        }
    }
}