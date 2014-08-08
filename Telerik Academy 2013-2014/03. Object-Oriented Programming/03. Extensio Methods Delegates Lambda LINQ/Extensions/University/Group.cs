namespace University
{
    using System.Text;

    public class Group
    {
        public uint GroupNumber { get; set; }

        public string DepartmentName { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("Group number: {0}\n", this.GroupNumber);
            result.AppendFormat("Department name: {0}\n", this.DepartmentName);

            return result.ToString();
        }
    }
}