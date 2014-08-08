// Tasks 18-19

namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Shell
    {
        private static List<Student> students;

        public static void Main()
        {
            students = new List<Student>
            {
                new Student 
                { 
                    FirstName = "Dimitar",
                    LastName = "Petrov",
                    GroupName = "1"
                },
                new Student 
                { 
                    FirstName = "Dimitra",
                    LastName = "Chankova",
                    GroupName = "2"
                },
                new Student 
                { 
                    FirstName = "Trifon",
                    LastName = "Zarezan",
                    GroupName = "3"
                },
                new Student 
                { 
                    FirstName = "Aristidis",
                    LastName = "Tsakis",
                    GroupName = "2"
                },
                new Student 
                { 
                    FirstName = "Milena",
                    LastName = "Krasimirova",
                    GroupName = "5"
                }
            };

            // Task 18
            OrderByGroupName();

            // Task 19
            OrderByGroupNameExtension();
        }

        private static void OrderByGroupName()
        {
            var orderByGroupName = students.OrderBy(st => st.GroupName);
            Console.WriteLine("The students grouped by their group names:\n");
            PrintStudents(orderByGroupName);
        }

        private static void OrderByGroupNameExtension()
        {
            var orderByGroupNameExtension = students.OrderByGroupName();
            Console.WriteLine("The students grouped by their group names:\n");
            PrintStudents(orderByGroupNameExtension);
        }

        private static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}