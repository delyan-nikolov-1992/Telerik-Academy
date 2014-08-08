namespace Education
{
    using System;
    using System.Collections.Generic;

    public class SchoolClass : ICommentable
    {
        private string textID;
        private readonly List<Student> students;
        private readonly List<Teacher> teachers;
        private List<string> comments;

        public SchoolClass(string textID)
        {
            this.TextID = textID;
            this.students = new List<Student>();
            this.teachers = new List<Teacher>();
            this.Comments = new List<string>();
        }

        public string TextID
        {
            get { return this.textID; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The text identifier of the class must be a valid string!");
                }

                this.textID = value;
            }
        }

        public List<Student> Students
        {
            get { return this.students; }
        }

        public List<Teacher> Teachers
        {
            get { return this.teachers; }
        }

        public List<string> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public void AddStudent(Student student)
        {
            // students have unique class number
            if (this.students.Exists(st => st.ClassNumber.Equals(student.ClassNumber)))
            {
                throw new ArgumentException("A student with the same class number already exists.");
            }

            this.students.Add(student);
        }
    }
}