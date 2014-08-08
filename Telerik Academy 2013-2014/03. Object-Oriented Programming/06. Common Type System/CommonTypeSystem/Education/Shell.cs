namespace Education
{
    using System;
    using System.Collections.Generic;

    public class Shell
    {
        public static void Main()
        {
            try
            {
                Student stefan = new Student("Stefan", "Petrov", "Georgiev", "12345A", "Studentski grad", "04897487",
                    "stefan@abv.bg", 3, Specialty.Chemistry, University.SofiaUniversity, Faculty.ChemistryAndBiology);
                Student pesho = new Student("Petar", "Petrov", "Petrov", "12451B", "Mladost 1", "088846312",
                    "peshkata@gmail.com", 2, Specialty.ComputerScience, University.TechnicalUniversityOfSofia,
                    Faculty.ComputerScience);
                Student stamat = new Student("Stamat", "Kirilov", "Spiridonov", "DDS##$F", "Opalchenska 12", "0256612",
                    "stami@abv.bg", 5, Specialty.Medicine, University.MedicalUniversitySofia, Faculty.ChemistryAndBiology);

                // initialize a student with the same name as pesho to show that the CompareTo Method 
                // compares students by names (as first criteria, in lexicographic order) and 
                // by social security number (as second criteria, in increasing order)
                Student peshosTwinBrother = new Student("Petar", "Petrov", "Petrov", "12551B", "Mladost 1", "088846312",
                    "peshkata@gmail.com", 2, Specialty.ComputerScience, University.TechnicalUniversityOfSofia,
                    Faculty.ComputerScience);

                Console.WriteLine(stefan);
                Console.WriteLine("Student Comparison");
                Console.WriteLine(stefan != pesho);
                Console.WriteLine(stefan == pesho);
                Console.WriteLine(stefan.Equals(pesho));

                var stefanClone = stefan.Clone();
                Console.WriteLine("\nPrinting Stefan Clone:");
                Console.WriteLine(stefanClone);

                // we are able to sort the student list because of the implementation of IComparable<Student> Interface
                Console.WriteLine("Sorting student List:\n");
                List<Student> students = new List<Student>();

                students.Add(pesho);
                students.Add(stefan);
                students.Add(stamat);
                students.Add(peshosTwinBrother);
                students.Sort();

                foreach (Student student in students)
                {
                    Console.WriteLine(student);
                }
            }
            catch (ArgumentNullException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}