namespace Society
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Shell
    {
        private static List<Student> students;
        private static List<Worker> workers;
        private static List<Human> humans;

        public static void Main()
        {
            try
            {
                students = new List<Student>
                {
                    new Student("Dimitar", "Mavrudiev", 4.50f),
                    new Student("Stefani", "Koleva", 3.15f),
                    new Student("Darth", "Vader", 2.00f),
                    new Student("Princess", "Leia", 6.00f),
                    new Student("Harry", "Potter", 4.92f),
                    new Student("Marina", "Petrakieva", 3.15f),
                    new Student("Pavel", "Trifonov", 5.50f),
                    new Student("Dimitar", "Berbatov", 5.99f),
                    new Student("Wayne", "Rooney", 3.00f),
                    new Student("Green", "Shreck", 3.01f),
                };

                workers = new List<Worker>
                {
                    new Worker("Kral", "Arthur", 1000.00f, 8),
                    new Worker("Stefani", "Koleva", 1380.22f, 10),
                    new Worker("Krasi", "Radkov", 200.00f, 12),
                    new Worker("Sasho", "Roman", 600.00f, 2),
                    new Worker("Ivo", "Andonov", 410.92f, 4),
                    new Worker("Martin", "Shmekera", 300.15f, 6),
                    new Worker("Ivaylo", "Kenov", 550.50f, 16),
                    new Worker("Trifon", "Zarezan", 599.99f, 1),
                    new Worker("Sveti", "Valentin", 3432.00f, 14),
                    new Worker("Christopher", "Columbus", 300.01f, 12),
                };

                humans = new List<Human>();

                // sorts the students by grade
                SortByGrade();

                // sorts the workers by money per hour
                SortByMoneyPerHour();

                // merges the two lists
                humans.AddRange(students);
                humans.AddRange(workers);

                // sorts the humans by first name and than by last name
                SortByName();
            }
            catch (ArgumentOutOfRangeException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (ArgumentNullException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private static void SortByGrade()
        {
            var studentsSortedByGrade = students.OrderBy(st => st.Grade);
            Console.WriteLine("The students sorted by grade in ascending order:\n");
            PrintHumans(studentsSortedByGrade);
        }

        private static void SortByMoneyPerHour()
        {
            var workersSortedByMoneyPerHour = workers.OrderByDescending(w => w.MoneyPerHour());
            Console.WriteLine("The workers sorted by money per hour in descending order:\n");
            PrintHumans(workersSortedByMoneyPerHour);
        }

        private static void SortByName()
        {
            var humansSortedByName = humans.OrderBy(h => h.FirstName).ThenBy(h => h.LastName);
            Console.WriteLine("The humans sorted by first name and then by last name:\n");
            PrintHumans(humansSortedByName);
        }

        private static void PrintHumans(IEnumerable<Human> humans)
        {
            foreach (var currentHuman in humans)
            {
                Console.WriteLine(currentHuman.ToString());
            }
        }
    }
}