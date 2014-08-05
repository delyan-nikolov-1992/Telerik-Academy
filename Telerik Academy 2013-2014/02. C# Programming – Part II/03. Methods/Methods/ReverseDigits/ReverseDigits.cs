using System;

class ReverseDigits
{
    static void Main()
    {
        try
        {
            Console.Write("The decimal number to be reversed: ");
            decimal number = decimal.Parse(Console.ReadLine());

            decimal result = ReverseNumber(number);

            Console.WriteLine("The reversed decimal number: {0}", result);
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }

    static decimal ReverseNumber(decimal number)
    {
        decimal result = 0;
        string representation = number.ToString();
        char[] digits = representation.ToCharArray();

        Array.Reverse(digits);

        result = decimal.Parse(new string(digits));

        return result;
    }
}