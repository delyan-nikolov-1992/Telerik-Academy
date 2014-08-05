//2. Secrets from Telerik Academy Exam 1 @ 24 June 2013 Evening

using System;

class Secrets
{
    static void Main()
    {
        string number = Console.ReadLine();
        string positiveNumber = null;

        if (number[0] == '-')
        {
            positiveNumber = number.Remove(0, 1);
        }
        else
        {
            positiveNumber = number;
        }

        int[] digits = new int[positiveNumber.Length];
        int specialSum = 0;

        for (int i = 0; i < positiveNumber.Length; i++)
        {
            digits[i] = Convert.ToInt32(positiveNumber[positiveNumber.Length - i - 1]) - 48;

            if (i % 2 == 0)
            {
                specialSum += (digits[i] * (i + 1) * (i + 1));
            }
            else
            {
                specialSum += (digits[i] * digits[i] * (i + 1));
            }
        }

        Console.WriteLine(specialSum);

        if (specialSum % 10 == 0)
        {
            Console.WriteLine(positiveNumber + " has no secret alpha-sequence");
        }
        else
        {
            int lastDigit = specialSum % 10;
            int lettersSum = specialSum % 26 + 1;
            int currentLetter;
            char letter;

            for (int i = 0; i < lastDigit; i++)
            {
                if (lettersSum == 27)
                {
                    lettersSum = 1;
                }
                letter = (char)(lettersSum + 64);
                lettersSum++;
                Console.Write(letter);
            }
            Console.WriteLine();
        }
    }
}