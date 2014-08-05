using System;

class CompareCharArrays
{
    static void Main()
    {
        try
        {
            Console.Write("The first char array as string: ");
            char[] firstString = Console.ReadLine().ToCharArray();
            Console.Write("The second char array as string: ");
            char[] secondString = Console.ReadLine().ToCharArray();
            int smallerLength;
            bool smallerString = false;

            if (firstString.Length >= secondString.Length)
            {
                smallerLength = secondString.Length;
            }
            else
            {
                smallerLength = firstString.Length;
            }

            for (int i = 0; i < smallerLength; i++)
            {
                if (firstString[i] < secondString[i])
                {
                    Console.WriteLine("The first char array is lexicographically before the second char array.");
                    smallerString = true;
                    break;
                }
                else if (firstString[i] > secondString[i])
                {
                    Console.WriteLine("The second char array is lexicographically before the first char array.");
                    smallerString = true;
                    break;
                }
            }

            if (!smallerString)
            {
                if (firstString.Length < secondString.Length)
                {
                    Console.WriteLine("The first char array is lexicographically before the second char array.");
                }
                else if (firstString.Length > secondString.Length)
                {
                    Console.WriteLine("The second char array is lexicographically before the first char array.");
                }
                else
                {
                    Console.WriteLine("The two char arrays are lexicographically equal.");
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}