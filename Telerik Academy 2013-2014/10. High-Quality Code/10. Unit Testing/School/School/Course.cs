namespace School
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private string name;
        private ICollection<Student> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name of the course should not be null or empty!");
                }

                this.name = value;
            }
        }

        public ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public int StudentsCount
        {
            get
            {
                return this.Students.Count;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.students.Count == 30)
            {
                throw new ArgumentOutOfRangeException("The students in the course are 30 and the course is full!");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            if (!this.students.Contains(student))
            {
                throw new ArgumentException("There is no such student in the course!");
            }

            this.students.Remove(student);
        }
    }
}