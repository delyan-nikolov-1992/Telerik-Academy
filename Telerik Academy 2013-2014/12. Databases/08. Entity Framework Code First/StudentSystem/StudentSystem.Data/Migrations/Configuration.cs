namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using StudentSystem.Model;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "StudentSystem.Data.StudentSystemDbContext";
        }

        protected override void Seed(StudentSystemDbContext context)
        {
            this.SeedStudents(context);
        }

        private void SeedStudents(StudentSystemDbContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            Course[] courses = new Course[] 
                                {
                                    new Course
                                    {
                                        Name = "C# Part 1",
                                        Description = "Not so hard course",
                                        Materials = "Programming, Innovation and Math"
                                    },
                                    new Course
                                    {
                                        Name = "C# Part 2",
                                        Description = "Harder than the first part",
                                        Materials = "Programming, Innovation and Math"
                                    },
                                    new Course
                                    {
                                        Name = "Algos",
                                        Materials = "Programming, Innovation and Math"
                                    },
                                };

            foreach (var course in courses)
            {
                context.Courses.Add(course);
            }

            context.Students.Add(new Student
            {
                FirstName = "Petar",
                LastName = "Petrov",
                FacultyNumber = "123456789A"
            });

            context.Students.Add(new Student
            {
                FirstName = "Krasi",
                LastName = "Minkov",
                FacultyNumber = "123456789B"
            });

            var student = new Student
            {
                FirstName = "Trifon",
                LastName = "Zarezan",
                FacultyNumber = "123456789C",
                Courses = courses
            };

            context.Students.Add(student);

            context.Homeworks.Add(new Homework 
            { 
                Content = "I have no time for this homework. Sorry",
                TimeSent = new DateTime(2014, 08, 31),
                Student = student,
                Course = courses[0]
            });

            context.Homeworks.Add(new Homework
            {
                Content = "No time for this one neither. Sorry",
                TimeSent = new DateTime(2014, 08, 31),
                Student = student,
                Course = courses[0]
            });
        }
    }
}