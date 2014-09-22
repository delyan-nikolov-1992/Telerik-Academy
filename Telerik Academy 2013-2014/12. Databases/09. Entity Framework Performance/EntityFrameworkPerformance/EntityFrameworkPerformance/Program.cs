namespace EntityFrameworkPerformance
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();

            // 1. Task
            stopwatch.Start();
            PrintEmployeesWithoutInclude();
            Console.WriteLine("Time elapsed (without Include): {0}\n", stopwatch.Elapsed);

            stopwatch.Restart();
            PrintEmployeesWithInclude();
            Console.WriteLine("Time elapsed (with Include): {0}\n", stopwatch.Elapsed);

            // 2. Task
            stopwatch.Restart();
            PrintEmployeesFromSofia();
            Console.WriteLine("Time elapsed (not optimized): {0}\n", stopwatch.Elapsed);

            stopwatch.Restart();
            PrintEmployeesFromSofiaOptimized();
            Console.WriteLine("Time elapsed (optimized): {0}\n", stopwatch.Elapsed);
        }

        private static void PrintEmployeesWithoutInclude()
        {
            using (var db = new TelerikAcademyEntities())
            {
                foreach (var currentEmployee in db.Employees)
                {
                    Console.WriteLine("Name: {0} {1}; Department: {2}; Town: {3}",
                        currentEmployee.FirstName,
                        currentEmployee.LastName,
                        currentEmployee.Department.Name,
                        currentEmployee.Address.Town.Name);
                }

                Console.WriteLine();
            }
        }

        private static void PrintEmployeesWithInclude()
        {
            using (var db = new TelerikAcademyEntities())
            {
                foreach (var currentEmployee in db.Employees.Include("Department").Include("Address.Town"))
                {
                    Console.WriteLine("Name: {0} {1}; Department: {2}; Town: {3}",
                        currentEmployee.FirstName,
                        currentEmployee.LastName,
                        currentEmployee.Department.Name,
                        currentEmployee.Address.Town.Name);
                }

                Console.WriteLine();
            }
        }

        private static void PrintEmployeesFromSofia()
        {
            using (var db = new TelerikAcademyEntities())
            {
                var employeesFromSofia = db.Employees
                    .ToList()
                    .Select(e => e.Address)
                    .ToList()
                    .Select(a => a.Town)
                    .ToList()
                    .Where(t => t.Name == "Sofia");

                Console.WriteLine("The number of employees from Sofia: {0}\n", employeesFromSofia.Count());
            }
        }

        private static void PrintEmployeesFromSofiaOptimized()
        {
            using (var db = new TelerikAcademyEntities())
            {
                var employeesFromSofia = db.Employees
                    .Select(e => e.Address.Town)
                    .Where(t => t.Name == "Sofia");

                Console.WriteLine("The number of employees from Sofia: {0}\n", employeesFromSofia.Count());
            }
        }
    }
}