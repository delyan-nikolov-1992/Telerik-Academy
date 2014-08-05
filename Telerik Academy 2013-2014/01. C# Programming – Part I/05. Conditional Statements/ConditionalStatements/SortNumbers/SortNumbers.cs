using System;

class SortNumbers
{
    static void Main()
    {
        try
        {
            Console.Write("The first number: ");
            double firstNumber = double.Parse(Console.ReadLine());
            Console.Write("The second number: ");
            double secondNumber = double.Parse(Console.ReadLine());
            Console.Write("The third number: ");
            double thirdNumber = double.Parse(Console.ReadLine());
            double fourthNumber;

            if (firstNumber < secondNumber)
            {
                fourthNumber = firstNumber;
                firstNumber = secondNumber;
                secondNumber = fourthNumber;
            }

            if (secondNumber < thirdNumber)
            {
                fourthNumber = secondNumber;
                secondNumber = thirdNumber;
                thirdNumber = fourthNumber;
            }

            if (firstNumber < secondNumber)
            {
                fourthNumber = firstNumber;
                firstNumber = secondNumber;
                secondNumber = fourthNumber;
            }

            Console.WriteLine("The biggest number is " + firstNumber);
            Console.WriteLine("The middle number is " + secondNumber);
            Console.WriteLine("The smallest number is " + thirdNumber);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}