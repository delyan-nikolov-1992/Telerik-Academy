using System;

class Comparator
{
    static void Main()
    {
        try
        {
            Console.Write("The first number: ");
            float firstNumber = float.Parse(Console.ReadLine());
            Console.Write("The second number: ");
            float secondNumber = float.Parse(Console.ReadLine());
            bool result;

            if (firstNumber == secondNumber)
                result = true;
            else
                result = false;

            Console.WriteLine(result);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}