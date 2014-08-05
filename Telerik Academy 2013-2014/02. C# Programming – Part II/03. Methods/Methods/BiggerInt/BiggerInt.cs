using System;

class BiggerInt
{
    static void Main()
    {
        try
        {
            Console.Write("First number to be checked: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Secind number to be checked: ");
            int secondNumber = int.Parse(Console.ReadLine());
            Console.Write("Third number to be checked: ");
            int thirdNumber = int.Parse(Console.ReadLine());

            int result = GetMax(GetMax(firstNumber, secondNumber), thirdNumber);

            Console.WriteLine("The biggest number is {0}", result);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static int GetMax(int firstNumber, int secondNumber)
    {
        int result = firstNumber;

        if (secondNumber > firstNumber)
        {
            result = secondNumber;
        }

        return result;
    }
}