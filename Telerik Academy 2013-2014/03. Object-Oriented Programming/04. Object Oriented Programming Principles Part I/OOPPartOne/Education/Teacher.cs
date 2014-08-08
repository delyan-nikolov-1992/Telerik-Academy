namespace Education
{
    using System.Collections.Generic;

    public class Teacher : Person
    {
        private readonly List<Discipline> disciplines;

        public Teacher(string name)
            : base(name)
        {
            this.disciplines = new List<Discipline>();
        }

        public List<Discipline> Disciplines
        {
            get { return this.disciplines; }
        }
    }
}