namespace Company.SampleDataGenerator
{
    using System;

    internal class Logger : ILogger
    {
        public Logger()
        {
        }

        public void LogMessage(string message)
        {
            Console.Write(message);
        }

        public void LogMessageWithNewLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}