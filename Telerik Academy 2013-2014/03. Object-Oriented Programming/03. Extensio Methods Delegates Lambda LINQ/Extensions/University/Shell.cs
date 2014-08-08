// Tasks 09-16

namespace University
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
                    FN = "12120612",
                    Tel = "02/8-43-44",
                    Email = "dimitar.petrov@gmail.com",
                    Marks = new List<int> { 2, 3, 4 },
                    Group = new Group { GroupNumber = 58, DepartmentName = "Mathematics" }
                },
                new Student 
                { 
                    FirstName = "Dimitra",
                    LastName = "Chankova",
                    FN = "00121106",
                    Tel = "0361/8-11-44",
                    Email = "drakonkata50@gmail.com",
                    Marks = new List<int> { 6, 5 },
                    Group = new Group { GroupNumber = 57, DepartmentName = "Mathematics" }
                },
                new Student 
                { 
                    FirstName = "Trifon",
                    LastName = "Zarezan",
                    FN = "121212",
                    Tel = "02/2-22-22",
                    Email = "cherveno_vino@abv.bg",
                    Marks = new List<int> { 2, 2, 2, 2 },
                    Group = new Group { GroupNumber = 2, DepartmentName = "Physics" }
                },
                new Student 
                { 
                    FirstName = "Aristidis",
                    LastName = "Tsakis",
                    FN = "0002121213",
                    Tel = "558/8-31-10",
                    Email = "the_greek_1990@abv.bg",
                    Marks = new List<int> { 6, 6, 6, 6 },
                    Group = new Group { GroupNumber = 14, DepartmentName = "Physics" }
                },
                new Student 
                { 
                    FirstName = "Milena",
                    LastName = "Krasimirova",
                    FN = "101006",
                    Tel = "52/8-14-13",
                    Email = "sladkata120@gmail.com",
                    Marks = new List<int> { 2, 3 },
                    Group = new Group { GroupNumber = 3, DepartmentName = "Chemistry" }
                }
            };

            // Task 09
            StudentsFromGroupTwo();
            StudentsOrderedByFirstName();

            // Task 10
            studentsFromSameGroup();
            studentsOrderedByFirstNameExtension();

            // Task 11
            studentsWithABVEmails();

            // Task 12
            studentsWithPhonesInSofia();

            // Task 13
            excellentStudents();

            // Task 14
            studentsWithTwoMarks();

            // Task 15
            marksOfStudentsEnrolledIn2006();

            // Task 16
            studentsFromSameDepartment();
        }

        private static void StudentsFromGroupTwo()
        {
            var studentsFromGroupTwo = students.Where(st => st.Group.GroupNumber == 2);
            Console.WriteLine("The students that are from group number 2:\n");
            PrintStudents(studentsFromGroupTwo);
        }

        private static void StudentsOrderedByFirstName()
        {
            var studentsOrderedByFirstName = students.OrderBy(st => st.FirstName);
            Console.WriteLine("The students ordered by their first names:\n");
            PrintStudents(studentsOrderedByFirstName);
        }

        private static void studentsFromSameGroup()
        {
            var studentsFromSameGroup = students.SameGroup(2);
            Console.WriteLine("The students that are from group number 2:\n");
            PrintStudents(studentsFromSameGroup);
        }

        private static void studentsOrderedByFirstNameExtension()
        {
            var studentsOrderedByFirstNameExtension = students.OrderByFirstName();
            Console.WriteLine("The students ordered by their first names:\n");
            PrintStudents(studentsOrderedByFirstNameExtension);
        }

        private static void studentsWithABVEmails()
        {
            var studentsWithABVEmails = students.Where(st => st.Email.EndsWith("@abv.bg"));
            Console.WriteLine("The students that have email in abv.bg:\n");
            PrintStudents(studentsWithABVEmails);
        }

        private static void studentsWithPhonesInSofia()
        {
            var studentsWithPhonesInSofia = students.Where(st => st.Tel.StartsWith("02"));
            Console.WriteLine("The students with phones in Sofia:\n");
            PrintStudents(studentsWithPhonesInSofia);
        }

        private static void excellentStudents()
        {
            var excellentStudents = students.Where(st => st.Marks.Contains(6))
                                            .Select(st => new
                                            {
                                                FullName = st.FirstName + " " + st.LastName,
                                                Marks = st.Marks
                                            });

            Console.WriteLine("The students that have at least one mark Excellent (6):\n");
            PrintAnonymousStudents(excellentStudents);
        }

        private static void studentsWithTwoMarks()
        {
            var studentsWithTwoMarks = students.SameNumberOfMarks(2).AnonymousStudents();
            Console.WriteLine("The students with exactly  two marks \"2\":\n");
            PrintAnonymousStudents(studentsWithTwoMarks);
        }

        private static void marksOfStudentsEnrolledIn2006()
        {
            var marksOfStudentsEnrolledIn2006 = students.Where(st => st.FN.Substring(4, 2).Equals("06"))
                                                        .Select(st => new
                                                        {
                                                            Marks = st.Marks
                                                        });
            Console.WriteLine("The marks of the students that enrolled in 2006:");
            PrintMarks(marksOfStudentsEnrolledIn2006);
        }

        private static void studentsFromSameDepartment()
        {
            Group[] groups = new Group[]
            {
                new Group { GroupNumber = 58, DepartmentName = "Mathematics" },
                new Group { GroupNumber = 2, DepartmentName = "Physics" },
                new Group { GroupNumber = 3, DepartmentName = "Chemistry" }
            };

            var studentsFromSameDepartment =
               from gr in groups
               join st in students on gr.DepartmentName equals st.Group.DepartmentName
               where gr.DepartmentName == "Mathematics"
               select st;

            Console.WriteLine("The students from \"Mathematics\" department:\n");
            PrintStudents(studentsFromSameDepartment);
        }

        private static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
        }

        private static void PrintAnonymousStudents(dynamic students)
        {
            foreach (var currentStudent in students)
            {
                Console.WriteLine("Full name: {0}", currentStudent.FullName);
                Console.Write("Marks: ");

                for (int i = 0; i < currentStudent.Marks.Count; i++)
                {
                    Console.Write(currentStudent.Marks[i]);

                    if (i != currentStudent.Marks.Count - 1)
                    {
                        Console.Write(", ");
                    }
                }

                Console.WriteLine("\n");
            }
        }

        private static void PrintMarks(dynamic allMarks)
        {
            bool first = false;

            foreach (var marks in allMarks)
            {
                foreach (var currentMark in marks.Marks)
                {
                    if (first)
                    {
                        Console.Write(", ");
                    }
                    else
                    {
                        first = true;
                    }

                    Console.Write(currentMark);
                }
            }

            Console.WriteLine("\n");
        }
    }
}