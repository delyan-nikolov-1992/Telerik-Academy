namespace Salaries
{
    using System;

    public class TestSalaries
    {
        private static long numberOfEmployees;

        private static bool[,] employees;
        private static long[] salaries;

        public static void Main()
        {
            numberOfEmployees = long.Parse(Console.ReadLine());

            employees = new bool[numberOfEmployees, numberOfEmployees];
            salaries = new long[numberOfEmployees];

            long result = 0;

            for (long i = 0; i < employees.GetLength(0); i++)
            {
                string row = Console.ReadLine();

                for (int j = 0; j < employees.GetLength(1); j++)
                {
                    employees[i, j] = row[j] == 'Y';
                }
            }

            for (long i = 0; i < salaries.Length; i++)
            {
                result += FindSalary(i);
            }

            Console.WriteLine(result);
        }

        private static long FindSalary(long employee)
        {
            if (salaries[employee] > 0)
            {
                return salaries[employee];
            }

            long salary = 0;

            for (long j = 0; j < employees.GetLength(1); j++)
            {
                if (employees[employee, j])
                {
                    salary += FindSalary(j);
                }
            }

            if (salary == 0)
            {
                salary = 1;
            }

            salaries[employee] = salary;

            return salary;
        }
    }
}