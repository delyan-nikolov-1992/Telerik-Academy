// Tasks 03-05

namespace LINQWithStudents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Shell
    {
        private static Student[] students;

        public static void Main()
        {
            students = new Student[]
            {
                new Student 
                { 
                    FirstName = "Dimitar",
                    LastName = "Petrov",
                    Age = 19
                },
                new Student 
                { 
                    FirstName = "Dimitar",
                    LastName = "Chankov",
                    Age = 30
                },
                new Student 
                { 
                    FirstName = "Trifon",
                    LastName = "Zarezan",
                    Age = 28
                },
                new Student 
                { 
                    FirstName = "Aristidis",
                    LastName = "Tsakis",
                    Age = 24
                },
                new Student 
                { 
                    FirstName = "Milena",
                    LastName = "Krasimirova",
                    Age = 20
                }
            };

            // Task 03
            FirstNameBeforeLastName();

            // Task 04
            FirstAndLastNamesOfStudents();

            // Task 05
            OrderByNamesWithLamba();
            OrderByNames();
        }

        private static void FirstNameBeforeLastName()
        {
            var firstNameBeforeLastName = students.Where(st => st.FirstName.CompareTo(st.LastName) < 0);
            Console.WriteLine("The students whose first name is before its last name alphabetically:\n");
            PrintStudents(firstNameBeforeLastName);
        }

        private static void FirstAndLastNamesOfStudents()
        {
            var firstAndLastNamesOfStudents = students.Where(st => st.Age >= 18 && st.Age <= 24)
                                            .Select(st => new
                                            {
                                                FirstName = st.FirstName,
                                                LastName = st.LastName
                                            });

            Console.WriteLine("The first name and last name of all students with age between 18 and 24:\n");
            PrintNames(firstAndLastNamesOfStudents);
        }

        private static void OrderByNamesWithLamba()
        {
            var orderByNames = students.OrderByDescending(st => st.FirstName).ThenByDescending(st => st.LastName);
            Console.WriteLine("The students sorted by first name and last name in descending order:\n");
            PrintStudents(orderByNames);
        }

        private static void OrderByNames()
        {
            var orderByNames =
                from st in students
                orderby st.FirstName descending, st.LastName descending
                select st;

            Console.WriteLine("The students sorted by first name and last name in descending order:\n");
            PrintStudents(orderByNames);
        }

        private static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }

        private static void PrintNames(dynamic names)
        {
            foreach (var currentName in names)
            {
                Console.WriteLine("First name: {0}", currentName.FirstName);
                Console.WriteLine("Last name: {0}\n", currentName.LastName);
            }
        }
    }
}