namespace Education
{
    using System;

    public class Student : Person
    {
        private string classNumber;

        public Student(string name, string classNumber)
            : base(name)
        {
            this.ClassNumber = classNumber;
        }

        public string ClassNumber
        {
            get { return this.classNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The class number of the student must be a valid string!");
                }

                this.classNumber = value;
            }
        }
    }
}