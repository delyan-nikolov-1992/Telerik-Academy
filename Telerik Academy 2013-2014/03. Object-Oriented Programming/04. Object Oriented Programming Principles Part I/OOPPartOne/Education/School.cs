namespace Education
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private readonly List<SchoolClass> schoolClasses;

        public School()
        {
            this.schoolClasses = new List<SchoolClass>();
        }

        public List<SchoolClass> SchoolClasses
        {
            get { return this.schoolClasses; }
        }

        public void AddSchoolClass(SchoolClass schoolClass)
        {
            // classes have unique text identifier
            if (this.schoolClasses.Exists(cl => cl.TextID.Equals(schoolClass.TextID)))
            {
                throw new ArgumentException("A student with the same class number already exists.");
            }

            this.schoolClasses.Add(schoolClass);
        }
    }
}