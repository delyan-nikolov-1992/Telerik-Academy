//1. Coffe Machine from Telerik Academy Exam 1 @ 23 June 2013

using System;

class CoffeeMachine
{
    static void Main()
    {
        double[] coins = new double[5];
        coins[0] = int.Parse(Console.ReadLine()) * 0.05;
        coins[1] = int.Parse(Console.ReadLine()) * 0.1;
        coins[2] = int.Parse(Console.ReadLine()) * 0.2;
        coins[3] = int.Parse(Console.ReadLine()) * 0.5;
        coins[4] = int.Parse(Console.ReadLine());
        double developerAmount = double.Parse(Console.ReadLine());
        double price = double.Parse(Console.ReadLine());
        double machineAmount = 0;
        double result;

        foreach (double current in coins)
        {
            machineAmount += current;
        }

        if (price - developerAmount > 0)
        {
            result = price - developerAmount;
            Console.WriteLine("More {0:F2}", result);
        }
        else if (machineAmount + price - developerAmount >= 0)
        {
            result = machineAmount + price - developerAmount;
            Console.WriteLine("Yes {0:F2}", result);
        }
        else
        {
            result = developerAmount - price - machineAmount;
            Console.WriteLine("No {0:F2}", result);
        }
    }
}