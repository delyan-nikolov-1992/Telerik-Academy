namespace ExceptionsHandling
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExceptionsHomework
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (arr.Length == 0)
            {
                throw new ArgumentNullException("The sequence should not be null!");
            }

            if (startIndex < 0 || startIndex >= arr.Length)
            {
                throw new ArgumentOutOfRangeException("The start index should be a valid index of the sequence!");
            }

            if (count < 0 || count + startIndex > arr.Length)
            {
                throw new ArgumentOutOfRangeException("There is no such subsequence!");
            }

            List<T> result = new List<T>();

            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException("The input string should not be empty or null!");
            }

            if (count > str.Length)
            {
                throw new ArgumentOutOfRangeException("The extracting is out of the range of the input string!");
            }

            StringBuilder result = new StringBuilder();

            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static void CheckPrime(int number)
        {
            bool isPrime = true;

            if (number < 2)
            {
                isPrime = false;
            }
            else
            {
                for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
                {
                    if (number % divisor == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }

            if (isPrime)
            {
                Console.WriteLine("{0} is prime.", number);
            }
            else
            {
                Console.WriteLine("{0} is not prime.", number);
            }
        }

        public static void Main()
        {
            try
            {
                var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
                Console.WriteLine(substr);

                var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
                Console.WriteLine(string.Join(" ", subarr));

                var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
                Console.WriteLine(string.Join(" ", allarr));

                var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
                Console.WriteLine(string.Join(" ", emptyarr));

                // uncomment the next line to catch exception
                // Console.WriteLine(ExtractEnding("Hi", 100));
                Console.WriteLine(ExtractEnding("I love C#", 2));
                Console.WriteLine(ExtractEnding("Nakov", 4));
                Console.WriteLine(ExtractEnding("beer", 4));

                CheckPrime(23);
                CheckPrime(33);

                List<Exam> peterExams = new List<Exam>()
                {
                    new SimpleMathExam(2),
                    new CSharpExam(55),
                    new CSharpExam(100),
                    new SimpleMathExam(1),
                    new CSharpExam(0),
                };

                Student peter = new Student("Peter", "Petrov", peterExams);
                double peterAverageResult = peter.CalcAverageExamResultInPercents();
                Console.WriteLine("Average results = {0:p0}", peterAverageResult);
            }
            catch (ArgumentOutOfRangeException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (ArgumentNullException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}