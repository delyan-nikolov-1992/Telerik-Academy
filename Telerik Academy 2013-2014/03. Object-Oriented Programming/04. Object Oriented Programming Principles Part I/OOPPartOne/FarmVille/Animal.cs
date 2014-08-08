namespace FarmVille
{
    using System;
    using System.Linq;

    public abstract class Animal
    {
        private byte age;
        private string name;
        private readonly bool isMale;

        public Animal(byte age, string name, bool isMale)
        {
            this.Age = age;
            this.Name = name;
            this.isMale = isMale;
        }

        public byte Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name of the animal must be a valid string!");
                }

                this.name = value;
            }
        }

        public bool IsMale
        {
            get { return this.isMale; }
        }

        public static double AverageAge(Animal[] animals)
        {
            double result = animals.Average(a => a.Age);

            return result;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}\nAge: {1}\nIs male: {2}", this.name, this.age, this.isMale);
        }
    }
}