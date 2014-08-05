using System;

class CheckNumber
{
    static int counter = 0;

    static void Main()
    {
        ReadNumber(1, 100);
    }

    static int ReadNumber(int start, int end)
    {
        int number = 0;

        try
        {
            Console.Write("Provide an integer number in the range ({0}, {1}): ", start, end);
            number = int.Parse(Console.ReadLine());
            counter++;

            if (number > start && number < end)
            {
                Console.WriteLine("The number {0} is in the range ({1}, {2}).", number, start, end);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            if (counter == 10)
            {
                return number;
            }
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("The number {0} is out of the range ({1}, {2}).", number, start, end);
            return 0;
        }
        catch (OverflowException)
        {
            Console.WriteLine("The number is out of the range for the integer type.");
            return 0;
        }
        catch (FormatException)
        {
            Console.WriteLine("Not an integer number.");
            return 0;
        }

        return ReadNumber(number, end);
    }
}