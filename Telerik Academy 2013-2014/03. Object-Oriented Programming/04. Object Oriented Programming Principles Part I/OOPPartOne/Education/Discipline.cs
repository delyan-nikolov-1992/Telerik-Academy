namespace Education
{
    using System;
    using System.Collections.Generic;

    public class Discipline : ICommentable
    {
        private string name;
        private uint numberOfLectures;
        private uint numberOfExercises;
        private List<string> comments;

        public Discipline(string name, uint numberOfLectures, uint numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
            this.Comments = new List<string>();
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name of the discipline must be a valid string!");
                }

                this.name = value;
            }
        }

        public uint NumberOfLectures
        {
            get { return this.numberOfLectures; }
            set { this.numberOfLectures = value; }
        }

        public uint NumberOfExercises
        {
            get { return this.numberOfExercises; }
            set { this.numberOfExercises = value; }
        }

        public List<string> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}