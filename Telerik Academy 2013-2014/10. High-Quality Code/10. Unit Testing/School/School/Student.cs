namespace School
{
    using System;

    public class Student
    {
        private string firstName;
        private string lastName;
        private uint id;

        public Student(string firstName, string lastName, uint id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The first name of the student should not be null or empty!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The last name of the student should not be null or empty!");
                }

                this.lastName = value;
            }
        }

        public uint Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("The id of the student should be between 10000 and 99999!");
                }

                this.id = value;
            }
        }
    }
}