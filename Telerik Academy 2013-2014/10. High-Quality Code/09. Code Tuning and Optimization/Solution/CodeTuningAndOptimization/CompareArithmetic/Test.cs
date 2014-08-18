namespace CompareArithmetic
{
    using System;
    using System.Diagnostics;

    public class Test
    {
        private const int NumberOfDashes = 50;
        private const int MaxValue = 500000;

        public static void Main()
        {
            Addition();
            Subtraction();
            Incrementation();
            Multiplication();
            Division();
        }

        private static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static void Addition()
        {
            Console.WriteLine(new string('-', NumberOfDashes));

            Console.Write("Addition for int:\t\t");
            DisplayExecutionTime(() =>
            {
                int counter = int.MinValue;

                for (int i = 0; i < MaxValue; i++)
                {
                    counter += i;
                }
            });

            Console.Write("Addition for long:\t\t");
            DisplayExecutionTime(() =>
            {
                long counter = int.MinValue;

                for (long i = 0; i < MaxValue; i++)
                {
                    counter += i;
                }
            });

            Console.Write("Addition for float:\t\t");
            DisplayExecutionTime(() =>
            {
                float counter = int.MinValue;

                for (float i = 0; i < MaxValue; i++)
                {
                    counter += i;
                }
            });

            Console.Write("Addition for double:\t\t");
            DisplayExecutionTime(() =>
            {
                double counter = int.MinValue;

                for (double i = 0; i < MaxValue; i++)
                {
                    counter += i;
                }
            });

            Console.Write("Addition for decimal:\t\t");
            DisplayExecutionTime(() =>
            {
                decimal counter = int.MinValue;

                for (decimal i = 0; i < MaxValue; i++)
                {
                    counter += i;
                }
            });
        }

        private static void Subtraction()
        {
            Console.WriteLine(new string('-', NumberOfDashes));

            Console.Write("Subtraction for int:\t\t");
            DisplayExecutionTime(() =>
            {
                int counter = int.MaxValue;

                for (int i = 0; i < MaxValue; i++)
                {
                    counter -= i;
                }
            });

            Console.Write("Subtraction for long:\t\t");
            DisplayExecutionTime(() =>
            {
                long counter = int.MaxValue;

                for (long i = 0; i < MaxValue; i++)
                {
                    counter -= i;
                }
            });

            Console.Write("Subtraction for float:\t\t");
            DisplayExecutionTime(() =>
            {
                float counter = int.MaxValue;

                for (float i = 0; i < MaxValue; i++)
                {
                    counter -= i;
                }
            });

            Console.Write("Subtraction for double:\t\t");
            DisplayExecutionTime(() =>
            {
                double counter = int.MaxValue;

                for (double i = 0; i < MaxValue; i++)
                {
                    counter -= i;
                }
            });

            Console.Write("Subtraction for decimal:\t");
            DisplayExecutionTime(() =>
            {
                decimal counter = int.MaxValue;

                for (decimal i = 0; i < MaxValue; i++)
                {
                    counter -= i;
                }
            });
        }

        private static void Incrementation()
        {
            Console.WriteLine(new string('-', NumberOfDashes));

            Console.Write("Incrementation for int:\t\t");
            DisplayExecutionTime(() =>
            {
                int counter = 0;

                for (int i = 0; i < MaxValue; i++)
                {
                    counter++;
                }
            });

            Console.Write("Incrementation for long:\t");
            DisplayExecutionTime(() =>
            {
                long counter = 0;

                for (long i = 0; i < MaxValue; i++)
                {
                    counter++;
                }
            });

            Console.Write("Incrementation for float:\t");
            DisplayExecutionTime(() =>
            {
                float counter = 0;

                for (float i = 0; i < MaxValue; i++)
                {
                    counter++;
                }
            });

            Console.Write("Incrementation for double:\t");
            DisplayExecutionTime(() =>
            {
                double counter = 0;

                for (double i = 0; i < MaxValue; i++)
                {
                    counter++;
                }
            });

            Console.Write("Incrementation for decimal:\t");
            DisplayExecutionTime(() =>
            {
                decimal counter = 0;

                for (decimal i = 0; i < MaxValue; i++)
                {
                    counter++;
                }
            });
        }

        private static void Multiplication()
        {
            Console.WriteLine(new string('-', NumberOfDashes));

            Console.Write("Multiplication for int:\t\t");
            DisplayExecutionTime(() =>
            {
                int counter = 2;

                for (int i = 1; i < MaxValue; i++)
                {
                    counter *= counter;
                }
            });

            Console.Write("Multiplication for long:\t");
            DisplayExecutionTime(() =>
            {
                long counter = 2;

                for (int i = 1; i < MaxValue; i++)
                {
                    counter *= counter;
                }
            });

            Console.Write("Multiplication for float:\t");
            DisplayExecutionTime(() =>
            {
                float counter = 2;

                for (int i = 1; i < MaxValue; i++)
                {
                    counter *= counter;
                }
            });

            Console.Write("Multiplication for double:\t");
            DisplayExecutionTime(() =>
            {
                double counter = 2;

                for (int i = 1; i < MaxValue; i++)
                {
                    counter *= counter;
                }
            });

            Console.Write("Multiplication for decimal:\t");
            DisplayExecutionTime(() =>
            {
                decimal counter = 1;

                for (int i = 1; i < MaxValue; i++)
                {
                    counter *= counter;
                }
            });
        }

        private static void Division()
        {
            Console.WriteLine(new string('-', NumberOfDashes));

            Console.Write("Division for int:\t\t");
            DisplayExecutionTime(() =>
            {
                int counter = int.MaxValue;

                for (int i = 1; i < MaxValue; i++)
                {
                    counter /= i;
                }
            });

            Console.Write("Divison for long:\t\t");
            DisplayExecutionTime(() =>
            {
                long counter = int.MaxValue;

                for (long i = 1; i < MaxValue; i++)
                {
                    counter /= i;
                }
            });

            Console.Write("Division for float:\t\t");
            DisplayExecutionTime(() =>
            {
                float counter = int.MaxValue;

                for (float i = 1; i < MaxValue; i++)
                {
                    counter /= i;
                }
            });

            Console.Write("Division for double:\t\t");
            DisplayExecutionTime(() =>
            {
                double counter = int.MaxValue;

                for (double i = 1; i < MaxValue; i++)
                {
                    counter /= i;
                }
            });

            Console.Write("Division for decimal:\t\t");
            DisplayExecutionTime(() =>
            {
                decimal counter = int.MaxValue;

                for (decimal i = 1; i < MaxValue; i++)
                {
                    counter /= i;
                }
            });
        }
    }
}