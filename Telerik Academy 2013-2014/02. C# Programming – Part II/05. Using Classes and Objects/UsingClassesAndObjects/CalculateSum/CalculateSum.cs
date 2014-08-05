using System;

class CalculateSum
{
    static void Main()
    {
        try
        {
            Console.Write("Enter the positive integers:");
            string[] values = Console.ReadLine().Split(' ');
            int result = Sum(values);

            Console.WriteLine("result = {0}", result);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static int Sum(string[] values)
    {
        int result = 0;

        foreach (string currentValue in values)
        {
            result += int.Parse(currentValue);
        }

        return result;
    }
}