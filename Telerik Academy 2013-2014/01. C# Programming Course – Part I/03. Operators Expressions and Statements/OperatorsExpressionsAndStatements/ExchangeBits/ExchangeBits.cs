using System;

class ExchangeBits
{
    static void Main()
    {
        try
        {
            Console.Write("The number to be changed: ");
            uint number = uint.Parse(Console.ReadLine());

            byte firstSequenceOfBits = 3;
            byte secondSequenceOfBits = 24;
            uint firstMask = 1;
            uint secondMask = 1;
            uint firstBit;
            uint secondBit;
            uint result;

            Console.WriteLine("The given number: " + number + " "
                                + Convert.ToString(number, 2).PadLeft(32, '0'));

            for (byte i = 0; i < 3; i++)
            {
                firstMask = firstMask << firstSequenceOfBits;
                result = number & firstMask;
                firstBit = result >> firstSequenceOfBits;

                secondMask = secondMask << secondSequenceOfBits;
                result = number & secondMask;
                secondBit = result >> secondSequenceOfBits;

                if (firstBit != secondBit)
                {
                    if (secondBit == 0)
                    {
                        firstMask = ~firstMask;
                        result = number & firstMask;
                        number = result;

                        if (firstBit == 0)
                        {
                            secondMask = ~secondMask;
                            result = number & secondMask;
                            number = result;
                        }
                        else
                        {
                            result = number | secondMask;
                            number = result;
                        }
                    }
                    else
                    {
                        result = number | firstMask;
                        number = result;

                        if (firstBit == 0)
                        {
                            secondMask = ~secondMask;
                            result = number & secondMask;
                            number = result;
                        }
                        else
                        {
                            result = number | secondMask;
                            number = result;
                        }
                    }
                }

                firstMask = 1;
                secondMask = 1;
                firstSequenceOfBits++;
                secondSequenceOfBits++;
            }

            Console.WriteLine("The number with exchanged bits: " + number + " "
                                + Convert.ToString(number, 2).PadLeft(32, '0'));
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}