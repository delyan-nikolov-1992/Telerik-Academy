namespace Person
{
    using System;
    using System.Text;

    public class Person
    {
        private string name;
        private byte? age;

        public Person(string name, byte? age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person(string name)
            : this(name, null)
        {

        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name of the person cannot be null ot empty!");
                }

                this.name = value;
            }
        }

        public byte? Age
        {
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format("Name: {0}", this.name));
            result.AppendLine(string.Format("Age: {0}", (this.age == null ? "not specified" : this.age.ToString())));

            return result.ToString();
        }
    }
}