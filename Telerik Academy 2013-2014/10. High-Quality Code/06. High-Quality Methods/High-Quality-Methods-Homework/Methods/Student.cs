namespace Methods
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string City { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsOlderThan(Student other)
        {
            return this.DateOfBirth < other.DateOfBirth;
        }
    }
}