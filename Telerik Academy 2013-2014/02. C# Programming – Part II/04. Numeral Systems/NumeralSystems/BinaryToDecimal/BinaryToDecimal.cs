using System;

class BinaryToDecimal
{
    static void Main()
    {
        try
        {
            Console.Write("The binary number to be converted: ");
            string binValue = Console.ReadLine();

            bool invalidNumber = false;

            //check whether the number is a binary number
            foreach (char digit in binValue)
            {
                if (digit != '0' && digit != '1')
                {
                    invalidNumber = true;
                    break;
                }
            }

            if (!invalidNumber)
            {
                int decValue = 0;

                for (int i = 0; i < binValue.Length; i++)
                {
                    if (binValue[binValue.Length - i - 1] == '0')
                    {
                        continue;
                    }

                    decValue += (int)Math.Pow(2, i);
                }

                Console.WriteLine(decValue);
            }
            else
            {
                Console.WriteLine("The given number is not a binary number.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}