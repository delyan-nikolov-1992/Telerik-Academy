// Task 06

namespace NumbersDivisibleBySevenAndThree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Shell
    {
        private static int[] numbers;

        public static void Main()
        {
            numbers = new int[] { 1, 2, 3, 7, 21, 42, 100 };

            DivisionBy7And3WithLamba();
            DivisionBy7And3();
        }

        private static void DivisionBy7And3WithLamba()
        {
            var divisionBy7And3WithLamba = numbers.Where(n => n % 7 == 0 && n %  3 == 0);
            Console.WriteLine("The numbers that are divisible by 7 and 3:");
            PrintStudents(divisionBy7And3WithLamba);
        }

        private static void DivisionBy7And3()
        {
            var divisionBy7And3 =
                from n in numbers
                where n % 7 == 0 && n % 3 == 0
                select n;

            Console.WriteLine("The numbers that are divisible by 7 and 3:");
            PrintStudents(divisionBy7And3);
        }

        private static void PrintStudents(IEnumerable<int> numbers)
        {
            foreach (var currentNumber in numbers)
            {
                Console.WriteLine(currentNumber.ToString());
            }

            Console.WriteLine();
        }
    }
}