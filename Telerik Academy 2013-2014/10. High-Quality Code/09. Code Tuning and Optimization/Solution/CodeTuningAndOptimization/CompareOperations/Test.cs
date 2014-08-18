namespace CompareOperations
{
    using System;
    using System.Diagnostics;

    public class Test
    {
        private const int NumberOfDashes = 50;
        private const float Value = float.MaxValue;

        public static void Main()
        {
            SquareRoot();
            NaturalLogarithm();
            Sinus();
        }

        private static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static void SquareRoot()
        {
            Console.WriteLine(new string('-', NumberOfDashes));

            Console.Write("Square root for float:\t\t");
            DisplayExecutionTime(() =>
            {
                float current = Value;
                Math.Sqrt(current);
            });

            Console.Write("Square root for double:\t\t");
            DisplayExecutionTime(() =>
            {
                double current = Value;
                Math.Sqrt(current);
            });

            Console.WriteLine("\nMath.Sqrt can not work with decimal values.\nThe value needs to be casted to double.");
        }

        private static void NaturalLogarithm()
        {
            Console.WriteLine(new string('-', NumberOfDashes));

            Console.Write("Natural Logarithm for float:\t");
            DisplayExecutionTime(() =>
            {
                float current = Value;
                Math.Log(current);
            });

            Console.Write("Natural Logarithm for double:\t");
            DisplayExecutionTime(() =>
            {
                double current = Value;
                Math.Log(current);
            });

            Console.WriteLine("\nMath.Log can not work with decimal values.\nThe value needs to be casted to double.");
        }

        private static void Sinus()
        {
            Console.WriteLine(new string('-', NumberOfDashes));

            Console.Write("Sinus for float:\t");
            DisplayExecutionTime(() =>
            {
                float current = Value;
                Math.Sin(current);
            });

            Console.Write("Sinus for double:\t");
            DisplayExecutionTime(() =>
            {
                double current = Value;
                Math.Sin(current);
            });

            Console.WriteLine("\nMath.Sin can not work with decimal values.\nThe value needs to be casted to double.");
        }
    }
}