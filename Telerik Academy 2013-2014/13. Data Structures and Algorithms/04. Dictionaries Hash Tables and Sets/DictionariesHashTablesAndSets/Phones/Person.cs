namespace Phones
{
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        public Person()
        {
            this.Names = new List<string>();
        }

        public IList<string> Names { get; set; }

        public string Town { get; set; }

        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Name: ");

            for (int i = 0; i < this.Names.Count - 1; i++)
            {
                result.Append(this.Names[i] + " ");
            }

            result.Append(string.Format("{0}; Town: {1}; Phone number: {1}",
                this.Names[this.Names.Count - 1],
                this.Town,
                this.PhoneNumber));

            return result.ToString();
        }
    }
}