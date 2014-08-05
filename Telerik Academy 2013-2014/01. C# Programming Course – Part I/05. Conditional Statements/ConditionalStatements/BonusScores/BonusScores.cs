using System;

class BonusScores
{
    static void Main()
    {
        try
        {
            Console.Write("The digit is: ");
            short digit = short.Parse(Console.ReadLine());

            switch (digit)
            {
                case 1:
                case 2:
                case 3:
                    digit *= 10;
                    Console.WriteLine(digit);
                    break;
                case 4:
                case 5:
                case 6:
                    digit *= 100;
                    Console.WriteLine(digit);
                    break;
                case 7:
                case 8:
                case 9:
                    digit *= 1000;
                    Console.WriteLine(digit);
                    break;
                case 0:
                default:
                    Console.WriteLine("The digit must be between 1 and 9 inclusive.");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}