namespace Students
{
    using System.Collections.Generic;

    public static class Extensions
    {
        // sorting the students by their group names with Selection Sort Algorithm
        public static List<Student> OrderByGroupName(this List<Student> students)
        {
            List<Student> result = students;
            int minElement;
            Student temp;

            for (int i = 0; i < result.Count - 1; i++)
            {
                minElement = i;

                for (int j = i + 1; j < result.Count; j++)
                {
                    if (result[j].GroupName.CompareTo(result[minElement].GroupName) < 0)
                    {
                        minElement = j;
                    }
                }

                if (minElement != i)
                {
                    temp = result[i];
                    result[i] = result[minElement];
                    result[minElement] = temp;
                }
            }

            return result;
        }
    }
}