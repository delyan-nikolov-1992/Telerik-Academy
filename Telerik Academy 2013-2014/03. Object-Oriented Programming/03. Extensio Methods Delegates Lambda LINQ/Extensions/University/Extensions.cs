namespace University
{
    using System.Collections.Generic;

    public static class Extensions
    {
        public static List<Student> SameGroup(this List<Student> students, uint groupNumber)
        {
            List<Student> result = new List<Student>();

            foreach (var currentStudent in students)
            {
                if (currentStudent.Group.GroupNumber == groupNumber)
                {
                    result.Add(currentStudent);
                }
            }

            return result;
        }

        // sorting the students by their first names with Selection Sort Algorithm
        public static List<Student> OrderByFirstName(this List<Student> students)
        {
            List<Student> result = students;
            int minElement;
            Student temp;

            for (int i = 0; i < result.Count - 1; i++)
            {
                minElement = i;

                for (int j = i + 1; j < result.Count; j++)
                {
                    if (result[j].FirstName.CompareTo(result[minElement].FirstName) < 0)
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

        public static List<Student> SameNumberOfMarks(this List<Student> students, int marksCounter)
        {
            List<Student> result = new List<Student>();

            foreach (var currentStudent in students)
            {
                if (currentStudent.Marks.Count == marksCounter)
                {
                    result.Add(currentStudent);
                }
            }

            return result;
        }

        public static dynamic AnonymousStudents(this List<Student> students)
        {
            dynamic result = new List<dynamic>();

            foreach (var currentStudent in students)
            {
                result.Add(new
                {
                    FullName = currentStudent.FirstName + " " + currentStudent.LastName,
                    Marks = currentStudent.Marks
                });
            }

            return result;
        }
    }
}