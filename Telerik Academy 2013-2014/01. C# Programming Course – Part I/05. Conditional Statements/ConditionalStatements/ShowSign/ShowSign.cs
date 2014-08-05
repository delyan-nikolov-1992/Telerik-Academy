using System;

class ShowSign
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

            if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
            {
                Console.WriteLine("The product is 0.");
            }
            else if ((firstNumber > 0 && ((secondNumber > 0 && thirdNumber > 0)
                        || (secondNumber < 0 && thirdNumber < 0))) || (firstNumber < 0
                        && ((secondNumber > 0 && thirdNumber < 0) || (secondNumber < 0 && thirdNumber > 0))))
            {
                Console.WriteLine("The sign of the product is + (plus).");
            }
            else
            {
                Console.WriteLine("The sign of the product is - (minus).");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}