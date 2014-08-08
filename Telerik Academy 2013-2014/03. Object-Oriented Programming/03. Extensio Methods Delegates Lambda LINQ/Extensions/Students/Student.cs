namespace Students
{
    using System.Text;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string GroupName { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("First name: {0}\n", this.FirstName);
            result.AppendFormat("Last name: {0}\n", this.LastName);
            result.AppendFormat("Group name: {0}\n", this.GroupName);

            return result.ToString();
        }
    }
}