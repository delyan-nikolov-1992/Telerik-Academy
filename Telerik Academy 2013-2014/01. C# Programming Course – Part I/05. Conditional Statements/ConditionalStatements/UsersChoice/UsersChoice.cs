using System;

class UsersChoice
{
    static void Main()
    {
        try
        {
            Console.Write("Choose 1 for int, 2 for double or 3 for String: ");
            byte choice = byte.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("The integer is: ");
                    int wholeNumber = int.Parse(Console.ReadLine()) + 1;
                    Console.WriteLine(wholeNumber);
                    break;
                case 2:
                    Console.Write("The double is: ");
                    double realNumber = double.Parse(Console.ReadLine()) + 1;
                    Console.WriteLine(realNumber);
                    break;
                case 3:
                    Console.Write("The string is: ");
                    string text = Console.ReadLine() + "*";
                    Console.WriteLine(text);
                    break;
                default:
                    Console.WriteLine("You have only three choices.");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}