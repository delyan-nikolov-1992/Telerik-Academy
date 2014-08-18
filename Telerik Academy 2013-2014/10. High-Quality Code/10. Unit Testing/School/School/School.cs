namespace School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private string name;
        private ICollection<Student> students;
        private ICollection<Course> courses;

        public School(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
            this.courses = new List<Course>();
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
                    throw new ArgumentNullException("The name of the school should not be null or empty!");
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

        public ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }
        }

        public int StudentsCount
        {
            get
            {
                return this.Students.Count;
            }
        }

        public int CoursesCount
        {
            get
            {
                return this.Courses.Count;
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("The student should not be null!");
            }

            foreach (var currentStudent in this.students)
            {
                if (currentStudent.Id == student.Id)
                {
                    throw new ArgumentException(string.Format("A student with id {0} already exists!", currentStudent.Id));
                }
            }

            this.students.Add(student);
        }

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("The course should not be null!");
            }

            this.courses.Add(course);
        }

        public void AddStudentToCourse(Student student, Course course)
        {
            if (student == null)
            {
                throw new ArgumentNullException("The student should not be null!");
            }

            if (course == null)
            {
                throw new ArgumentNullException("The course should not be null!");
            }

            if (!this.students.Contains(student))
            {
                throw new ArgumentException("There is no such student in the school!");
            }

            if (!this.courses.Contains(course))
            {
                throw new ArgumentException("There is no such course in the school!");
            }

            course.AddStudent(student);
        }

        public void RemoveStudentFromCourse(Student student, Course course)
        {
            if (student == null)
            {
                throw new ArgumentNullException("The student should not be null!");
            }

            if (course == null)
            {
                throw new ArgumentNullException("The course should not be null!");
            }

            if (!this.students.Contains(student))
            {
                throw new ArgumentException("There is no such student in the school!");
            }

            if (!this.courses.Contains(course))
            {
                throw new ArgumentException("There is no such course in the school!");
            }

            course.RemoveStudent(student);
        }
    }
}