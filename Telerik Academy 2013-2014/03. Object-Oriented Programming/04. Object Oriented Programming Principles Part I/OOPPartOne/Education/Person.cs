namespace Education
{
    using System;
    using System.Collections.Generic;

    public abstract class Person : ICommentable
    {
        private string name;
        private List<string> comments;

        public Person(string name)
        {
            this.Name = name;
            this.Comments = new List<string>();
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("The name of the person must be a valid string!");
                }

                this.name = value;
            }
        }

        public List<string> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public override string ToString()
        {
            return string.Format("Name: {0}", this.name);
        }
    }
}