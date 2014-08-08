namespace Society
{
    using System;
    using System.Text;

    public class Student : Human
    {
        private float grade;

        public Student(string firstName, string lastName, float grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public float Grade
        {
            get { return this.grade; }

            set
            {
                // if we assume that the grades are between 2.00 and 6.00 as in Bulgaria
                // always can change the values from here
                if (value < 2 || value > 6)
                {
                    throw new ArgumentOutOfRangeException("The grade of the student must be between 2.0 and 6.0!");
                }

                this.grade = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine("Student:");
            result.AppendLine(base.ToString());
            result.AppendFormat("Grade: {0:F2}\n", this.grade);

            return result.ToString();
        }
    }
}