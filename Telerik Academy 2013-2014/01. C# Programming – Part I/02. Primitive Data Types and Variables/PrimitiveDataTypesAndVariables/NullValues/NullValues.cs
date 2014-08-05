using System;

class NullValues
{
    static void Main()
    {
        int? firstNumber = null;
        double? secondNumber = null;

        Console.WriteLine(firstNumber + " " + secondNumber);

        firstNumber += 5;
        secondNumber += 5.3;

        Console.WriteLine(firstNumber + " " + secondNumber);
    }
}