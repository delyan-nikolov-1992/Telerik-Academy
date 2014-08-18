using System;

public class Test
{
    private const int MAX_COUNTER = 6;

    public static void Main()
    {
        Printer printer = new Printer();
        printer.Print(true);
    }

    private class Printer
    {
        public void Print(bool condition)
        {
            string stringRepresentation = condition.ToString();
            Console.WriteLine(stringRepresentation);
        }
    }
}