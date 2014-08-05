using System;

class GreaterNumber
{
    static void Main()
    {
        try
        {
            Console.Write("The first number = ");
            double firstNumber = double.Parse(Console.ReadLine());
            Console.Write("The second number = ");
            double secondNumber = double.Parse(Console.ReadLine());
            Console.Write("The third number = ");
            double thirdNumber = double.Parse(Console.ReadLine());
            Console.Write("The fourth number = ");
            double fourthNumber = double.Parse(Console.ReadLine());
            Console.Write("The fifth number = ");
            double fifthNumber = double.Parse(Console.ReadLine());

            if (firstNumber >= secondNumber && firstNumber >= thirdNumber
                                           && firstNumber >= fourthNumber && firstNumber >= fifthNumber)
            {
                Console.WriteLine("The biggest number is " + firstNumber);
            }
            else if (secondNumber >= firstNumber && secondNumber >= thirdNumber
                                           && secondNumber >= fourthNumber && secondNumber >= fifthNumber)
            {
                Console.WriteLine("The biggest number is " + secondNumber);
            }
            else if (thirdNumber >= firstNumber && thirdNumber >= secondNumber
                                           && thirdNumber >= fourthNumber && thirdNumber >= fifthNumber)
            {
                Console.WriteLine("The biggest number is " + thirdNumber);
            }
            else if (fourthNumber >= firstNumber && fourthNumber >= secondNumber
                                           && fourthNumber >= thirdNumber && fourthNumber >= fifthNumber)
            {
                Console.WriteLine("The biggest number is " + fourthNumber);
            }
            else
            {
                Console.WriteLine("The biggest number is " + fifthNumber);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}