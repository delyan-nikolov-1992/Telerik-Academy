using System;

class ExchangeGivenBits
{
    static void Main()
    {
        try
        {
            Console.Write("The number to be changed: ");
            uint number = uint.Parse(Console.ReadLine());
            Console.Write("The first bit of the first sequence to be changed: ");
            byte firstSequenceOfBits = byte.Parse(Console.ReadLine());
            Console.Write("The first bit of the second sequence to be changed: ");
            byte secondSequenceOfBits = byte.Parse(Console.ReadLine());
            Console.Write("The number of the bits to be changed in each sequence: ");
            byte value = byte.Parse(Console.ReadLine());

            if ((firstSequenceOfBits + value <= 31) && (secondSequenceOfBits + value <= 31))
            {
                uint firstMask = 1;
                uint secondMask = 1;
                uint FirstBit;
                uint secondBit;
                uint result;

                Console.WriteLine("The given number: " + number + " "
                                    + Convert.ToString(number, 2).PadLeft(32, '0'));

                for (byte i = 0; i < value; i++)
                {
                    firstMask = firstMask << firstSequenceOfBits;
                    result = number & firstMask;
                    FirstBit = result >> firstSequenceOfBits;

                    secondMask = secondMask << secondSequenceOfBits;
                    result = number & secondMask;
                    secondBit = result >> secondSequenceOfBits;

                    if (FirstBit != secondBit)
                    {
                        if (secondBit == 0)
                        {
                            firstMask = ~firstMask;
                            result = number & firstMask;
                            number = result;

                            if (FirstBit == 0)
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

                            if (FirstBit == 0)
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
            else
                Console.WriteLine("The bits cannot be greater than 32.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}