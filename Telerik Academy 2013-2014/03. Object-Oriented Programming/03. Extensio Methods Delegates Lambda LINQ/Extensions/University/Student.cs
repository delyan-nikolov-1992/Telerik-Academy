namespace University
{
    using System.Collections.Generic;
    using System.Text;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FN { get; set; }

        public string Tel { get; set; }

        public string Email { get; set; }

        public List<int> Marks { get; set; }

        public Group Group { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("First name: {0}\n", this.FirstName);
            result.AppendFormat("Last name: {0}\n", this.LastName);
            result.AppendFormat("Student number: {0}\n", this.FN);
            result.AppendFormat("Tel: {0}\n", this.Tel);
            result.AppendFormat("E-mail: {0}\n", this.Email);
            result.Append("Marks: ");

            for (int i = 0; i < this.Marks.Count; i++)
            {
                result.Append(this.Marks[i]);

                if (i != this.Marks.Count - 1)
                {
                    result.Append(", ");
                }
            }

            result.AppendFormat("\n" + this.Group.ToString());

            return result.ToString();
        }
    }
}