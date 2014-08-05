using System;

class ExchangeValues
{
    static void Main()
    {
        int firstNumber = 5;
        int secondNumber = 10;
        int thirdNumber;

        thirdNumber = firstNumber;
        firstNumber = secondNumber;
        secondNumber = thirdNumber;

        Console.WriteLine("The new first number is " + firstNumber);
        Console.WriteLine("The new second number is " + secondNumber);
    }
}