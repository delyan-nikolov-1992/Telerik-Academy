namespace StudentSystem.ConsoleClient
{
    using System;

    using StudentSystem.Data;
    using StudentSystem.Model;

    public class StudentSystemConsoleClient
    {
        public static void Main()
        {
            using (var db = new StudentSystemDbContext())
            {
                Console.WriteLine("All students:");
                PrintAllStudents(db);

                Console.WriteLine("\nAll courses:");
                PrintAllCourses(db);
            }
        }

        public static void PrintAllStudents(StudentSystemDbContext db)
        {
            var students = db.Students;

            foreach (var student in students)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName);
            }
        }

        public static void PrintAllCourses(StudentSystemDbContext db)
        {
            var courses = db.Courses;

            foreach (var course in courses)
            {
                Console.WriteLine(course.Name);
            }
        }
    }
}