using System;

class LastDigit
{
    static void Main()
    {
        try
        {
            Console.Write("The number to be checked: ");
            int number = int.Parse(Console.ReadLine());

            string lastDigit = GetLastDigit(number);

            Console.WriteLine(lastDigit);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static string GetLastDigit(int number)
    {
        string result = null;

        if (number < 0)
        {
            number *= -1;
        }

        byte digit = (byte)(number % 10);

        switch (digit)
        {
            case 0:
                result = "zero";
                break;
            case 1:
                result = "one";
                break;
            case 2:
                result = "two";
                break;
            case 3:
                result = "three";
                break;
            case 4:
                result = "four";
                break;
            case 5:
                result = "five";
                break;
            case 6:
                result = "six";
                break;
            case 7:
                result = "seven";
                break;
            case 8:
                result = "eight";
                break;
            case 9:
                result = "nine";
                break;
        }

        return result;
    }
}