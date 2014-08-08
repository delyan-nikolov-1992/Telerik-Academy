namespace Education
{
    using System;
    using System.Text;

    public class Student : ICloneable, IComparable<Student>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string socialSecurityNumber;
        private string address;
        private string mobilePhone;
        private string eMail;
        private byte course;
        private Specialty specialty;
        private University university;
        private Faculty faculty;

        public Student(string firstName, string middleName, string lastName, string socialSecurityNumber, string address,
            string mobilePhone, string eMail, byte course, Specialty specialty, University university, Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SocialSecurityNumber = socialSecurityNumber;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.EMail = eMail;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        public string FirstName
        {
            get { return this.firstName; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The first name of the student must be valid!");
                }

                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get { return this.middleName; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The middle name of the student must be valid!");
                }

                this.middleName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The last name of the student must be valid!");
                }

                this.lastName = value;
            }
        }

        public string SocialSecurityNumber
        {
            get { return this.socialSecurityNumber; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The social security number of the student must be valid!");
                }

                this.socialSecurityNumber = value;
            }
        }

        public string Address
        {
            get { return this.address; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The address of the student must be valid!");
                }

                this.address = value;
            }
        }

        public string MobilePhone
        {
            get { return this.mobilePhone; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The mobile phone of the student must be valid!");
                }

                this.mobilePhone = value;
            }
        }

        public string EMail
        {
            get { return this.eMail; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The e-mail of the student must be valid!");
                }

                this.eMail = value;
            }
        }

        public byte Course
        {
            get { return this.course; }
            set { this.course = value; }
        }

        public Specialty Specialty
        {
            get { return this.specialty; }
            set { this.specialty = value; }
        }

        public University University
        {
            get { return this.university; }
            set { this.university = value; }
        }

        public Faculty Faculty
        {
            get { return this.faculty; }
            set { this.faculty = value; }
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return Student.Equals(student1, student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !Student.Equals(student1, student2);
        }

        // Implicit implementation
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        // the method Clone()
        public Student Clone()
        {
            Student result = new Student(this.firstName, this.middleName, this.lastName, this.socialSecurityNumber,
                this.address, this.mobilePhone, this.eMail, this.course, this.specialty, this.university, this.faculty);

            return result;
        }

        public int CompareTo(Student otherStudent)
        {
            if (!this.firstName.Equals(otherStudent.firstName))
            {
                return this.firstName.CompareTo(otherStudent.firstName);
            }
            else if (!this.middleName.Equals(otherStudent.middleName))
            {
                return this.middleName.CompareTo(otherStudent.middleName);
            }
            else if (!this.lastName.Equals(otherStudent.lastName))
            {
                return this.lastName.CompareTo(otherStudent.lastName);
            }
            else if (!this.socialSecurityNumber.Equals(otherStudent.socialSecurityNumber))
            {
                return this.socialSecurityNumber.CompareTo(otherStudent.socialSecurityNumber);
            }

            return 0;
        }

        public override int GetHashCode()
        {
            return this.socialSecurityNumber.GetHashCode();
        }

        // all students have different social security number
        public override bool Equals(object param)
        {
            // If the cast is invalid, the result will be null
            Student student = param as Student;

            // Check if we have valid not null Student object
            if (student == null)
            {
                return false;
            }

            // Compare the reference type member fields
            if (!Object.Equals(this.socialSecurityNumber, student.socialSecurityNumber))
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("First name: {0}\n", this.firstName);
            result.AppendFormat("Middle name: {0}\n", this.middleName);
            result.AppendFormat("Last name: {0}\n", this.lastName);
            result.AppendFormat("Social security number: {0}\n", this.socialSecurityNumber);
            result.AppendFormat("Address: {0}\n", this.address);
            result.AppendFormat("Mobile phone: {0}\n", this.mobilePhone);
            result.AppendFormat("E-mail: {0}\n", this.eMail);
            result.AppendFormat("Course: {0}\n", this.course);
            result.AppendFormat("Specialty: {0}\n", this.specialty);
            result.AppendFormat("University: {0}\n", this.university);
            result.AppendFormat("Faculty: {0}\n", this.faculty);

            return result.ToString();
        }
    }
}