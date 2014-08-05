using System;

class ConvertNumberToText
{
    static void Main()
    {
        try
        {
            Console.Write("The number to be converted: ");
            int number = int.Parse(Console.ReadLine());

            if (number >= 0 && number <= 999)
            {
                string[] digits = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
                string[] teens = { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen",  "Sixteen", 
                                      "Seventeen", "Eighteen", "Nineteen", };
                string[] tenths = { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number / 10 == 0)
                {
                    switch (number)
                    {
                        case 0:
                            Console.WriteLine(digits[number]);
                            break;
                        case 1:
                            Console.WriteLine(digits[number]);
                            break;
                        case 2:
                            Console.WriteLine(digits[number]);
                            break;
                        case 3:
                            Console.WriteLine(digits[number]);
                            break;
                        case 4:
                            Console.WriteLine(digits[number]);
                            break;
                        case 5:
                            Console.WriteLine(digits[number]);
                            break;
                        case 6:
                            Console.WriteLine(digits[number]);
                            break;
                        case 7:
                            Console.WriteLine(digits[number]);
                            break;
                        case 8:
                            Console.WriteLine(digits[number]);
                            break;
                        case 9:
                            Console.WriteLine(digits[number]);
                            break;
                    }
                }
                else if (number / 100 == 0)
                {
                    int firstDigit = number / 10;
                    int secondDigit = number % 10;

                    if (firstDigit < 2)
                    {
                        switch (secondDigit)
                        {
                            case 0:
                                Console.WriteLine(teens[secondDigit]);
                                break;
                            case 1:
                                Console.WriteLine(teens[secondDigit]);
                                break;
                            case 2:
                                Console.WriteLine(teens[secondDigit]);
                                break;
                            case 3:
                                Console.WriteLine(teens[secondDigit]);
                                break;
                            case 4:
                                Console.WriteLine(teens[secondDigit]);
                                break;
                            case 5:
                                Console.WriteLine(teens[secondDigit]);
                                break;
                            case 6:
                                Console.WriteLine(teens[secondDigit]);
                                break;
                            case 7:
                                Console.WriteLine(teens[secondDigit]);
                                break;
                            case 8:
                                Console.WriteLine(teens[secondDigit]);
                                break;
                            case 9:
                                Console.WriteLine(teens[secondDigit]);
                                break;
                        }
                    }
                    else
                    {
                        switch (firstDigit)
                        {
                            case 2:
                                Console.Write(tenths[firstDigit - 2]);
                                break;
                            case 3:
                                Console.Write(tenths[firstDigit - 2]);
                                break;
                            case 4:
                                Console.Write(tenths[firstDigit - 2]);
                                break;
                            case 5:
                                Console.Write(tenths[firstDigit - 2]);
                                break;
                            case 6:
                                Console.Write(tenths[firstDigit - 2]);
                                break;
                            case 7:
                                Console.Write(tenths[firstDigit - 2]);
                                break;
                            case 8:
                                Console.Write(tenths[firstDigit - 2]);
                                break;
                            case 9:
                                Console.Write(tenths[firstDigit - 2]);
                                break;
                        }

                        if (secondDigit == 0)
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.Write(" ");
                            switch (secondDigit)
                            {
                                case 1:
                                    Console.WriteLine(digits[secondDigit].ToLower());
                                    break;
                                case 2:
                                    Console.WriteLine(digits[secondDigit].ToLower());
                                    break;
                                case 3:
                                    Console.WriteLine(digits[secondDigit].ToLower());
                                    break;
                                case 4:
                                    Console.WriteLine(digits[secondDigit].ToLower());
                                    break;
                                case 5:
                                    Console.WriteLine(digits[secondDigit].ToLower());
                                    break;
                                case 6:
                                    Console.WriteLine(digits[secondDigit].ToLower());
                                    break;
                                case 7:
                                    Console.WriteLine(digits[secondDigit].ToLower());
                                    break;
                                case 8:
                                    Console.WriteLine(digits[secondDigit].ToLower());
                                    break;
                                case 9:
                                    Console.WriteLine(digits[secondDigit].ToLower());
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    int firstDigit = number / 100;
                    int secondDigit = (number / 10) % 10;
                    int thirdDigit = number % 10;
                    string hundred = " hundred";

                    switch (firstDigit)
                    {
                        case 1:
                            Console.Write(digits[firstDigit]);
                            break;
                        case 2:
                            Console.Write(digits[firstDigit]);
                            break;
                        case 3:
                            Console.Write(digits[firstDigit]);
                            break;
                        case 4:
                            Console.Write(digits[firstDigit]);
                            break;
                        case 5:
                            Console.Write(digits[firstDigit]);
                            break;
                        case 6:
                            Console.Write(digits[firstDigit]);
                            break;
                        case 7:
                            Console.Write(digits[firstDigit]);
                            break;
                        case 8:
                            Console.Write(digits[firstDigit]);
                            break;
                        case 9:
                            Console.Write(digits[firstDigit]);
                            break;
                    }

                    Console.Write(hundred);

                    if (secondDigit == 0 && thirdDigit == 0)
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        if (secondDigit == 0)
                        {

                            Console.Write(" and ");

                            switch (thirdDigit)
                            {
                                case 1:
                                    Console.WriteLine(digits[thirdDigit].ToLower());
                                    break;
                                case 2:
                                    Console.WriteLine(digits[thirdDigit].ToLower());
                                    break;
                                case 3:
                                    Console.WriteLine(digits[thirdDigit].ToLower());
                                    break;
                                case 4:
                                    Console.WriteLine(digits[thirdDigit].ToLower());
                                    break;
                                case 5:
                                    Console.WriteLine(digits[thirdDigit].ToLower());
                                    break;
                                case 6:
                                    Console.WriteLine(digits[thirdDigit].ToLower());
                                    break;
                                case 7:
                                    Console.WriteLine(digits[thirdDigit].ToLower());
                                    break;
                                case 8:
                                    Console.WriteLine(digits[thirdDigit].ToLower());
                                    break;
                                case 9:
                                    Console.WriteLine(digits[thirdDigit].ToLower());
                                    break;
                            }
                        }
                        else if (secondDigit == 1)
                        {
                            Console.Write(" and ");

                            switch (thirdDigit)
                            {
                                case 0:
                                    Console.WriteLine(teens[thirdDigit].ToLower());
                                    break;
                                case 1:
                                    Console.WriteLine(teens[thirdDigit].ToLower());
                                    break;
                                case 2:
                                    Console.WriteLine(teens[thirdDigit].ToLower());
                                    break;
                                case 3:
                                    Console.WriteLine(teens[thirdDigit].ToLower());
                                    break;
                                case 4:
                                    Console.WriteLine(teens[thirdDigit].ToLower());
                                    break;
                                case 5:
                                    Console.WriteLine(teens[thirdDigit].ToLower());
                                    break;
                                case 6:
                                    Console.WriteLine(teens[thirdDigit].ToLower());
                                    break;
                                case 7:
                                    Console.WriteLine(teens[thirdDigit].ToLower());
                                    break;
                                case 8:
                                    Console.WriteLine(teens[thirdDigit].ToLower());
                                    break;
                                case 9:
                                    Console.WriteLine(teens[thirdDigit].ToLower());
                                    break;
                            }
                        }
                        else
                        {
                            Console.Write(" ");

                            if (thirdDigit == 0)
                            {
                                Console.Write("and ");
                            }

                            switch (secondDigit)
                            {
                                case 2:
                                    Console.Write(tenths[secondDigit - 2].ToLower());
                                    break;
                                case 3:
                                    Console.Write(tenths[secondDigit - 2].ToLower());
                                    break;
                                case 4:
                                    Console.Write(tenths[secondDigit - 2].ToLower());
                                    break;
                                case 5:
                                    Console.Write(tenths[secondDigit - 2].ToLower());
                                    break;
                                case 6:
                                    Console.Write(tenths[secondDigit - 2].ToLower());
                                    break;
                                case 7:
                                    Console.Write(tenths[secondDigit - 2].ToLower());
                                    break;
                                case 8:
                                    Console.Write(tenths[secondDigit - 2].ToLower());
                                    break;
                                case 9:
                                    Console.Write(tenths[secondDigit - 2].ToLower());
                                    break;
                            }

                            if (thirdDigit == 0)
                            {
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.Write(" ");

                                switch (thirdDigit)
                                {
                                    case 1:
                                        Console.WriteLine(digits[thirdDigit].ToLower());
                                        break;
                                    case 2:
                                        Console.WriteLine(digits[thirdDigit].ToLower());
                                        break;
                                    case 3:
                                        Console.WriteLine(digits[thirdDigit].ToLower());
                                        break;
                                    case 4:
                                        Console.WriteLine(digits[thirdDigit].ToLower());
                                        break;
                                    case 5:
                                        Console.WriteLine(digits[thirdDigit].ToLower());
                                        break;
                                    case 6:
                                        Console.WriteLine(digits[thirdDigit].ToLower());
                                        break;
                                    case 7:
                                        Console.WriteLine(digits[thirdDigit].ToLower());
                                        break;
                                    case 8:
                                        Console.WriteLine(digits[thirdDigit].ToLower());
                                        break;
                                    case 9:
                                        Console.WriteLine(digits[thirdDigit].ToLower());
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("The number must be between 0 and 999 inclusive.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}