namespace LINQWithStudents
{
    using System.Text;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("First name: {0}\n", this.FirstName);
            result.AppendFormat("Last name: {0}\n", this.LastName);
            result.AppendFormat("Group name: {0}\n", this.Age);

            return result.ToString();
        }
    }
}