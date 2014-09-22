namespace Company.SampleDataGenerator
{
    internal interface ILogger
    {
        void LogMessage(string message);

        void LogMessageWithNewLine(string message);
    }
}