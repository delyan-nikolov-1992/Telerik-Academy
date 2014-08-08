namespace Education
{
    using System;

    public class Shell
    {
        public static void Main()
        {
            try
            {
                // the test can be multiple for the multiple things
                // this is a little test for one class in one school with few students and teachers
                School school = new School();
                school.AddSchoolClass(new SchoolClass("A1"));
                school.SchoolClasses[0].AddStudent(new Student("Stefan", "A11"));
                school.SchoolClasses[0].AddStudent(new Student("Kristi", "A12"));
                school.SchoolClasses[0].AddStudent(new Student("Milena", "A13"));
                school.SchoolClasses[0].Students[1].Comments.Add("Hello, I'm Kristi!");
                school.SchoolClasses[0].Students[1].Comments.Add("Hello, I'm Kristi again!");
                school.SchoolClasses[0].Students[2].Comments.Add("Hello, I'm Milena!");
                school.SchoolClasses[0].Teachers.Add(new Teacher("Mr. Schmidt"));
                school.SchoolClasses[0].Teachers.Add(new Teacher("Mr. Arsov"));

                foreach (var currentStudent in school.SchoolClasses[0].Students)
                {
                    Console.WriteLine(currentStudent.ToString());
                }

                foreach (var currentTeacher in school.SchoolClasses[0].Teachers)
                {
                    Console.WriteLine(currentTeacher.ToString());
                }
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}