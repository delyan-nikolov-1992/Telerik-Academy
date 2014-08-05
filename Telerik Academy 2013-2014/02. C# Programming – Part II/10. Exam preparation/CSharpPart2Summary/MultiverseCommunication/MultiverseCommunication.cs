// 1. Multiverse Communication from C# Part 2 - 2013/2014 @ 14 Sept 2013 - Morning

using System;
using System.Text;

class MultiverseCommunication
{
    static void Main()
    {
        string text = Console.ReadLine();
        StringBuilder number = new StringBuilder();

        for (int i = 0; i < text.Length; i += 3)
        {
            number.Append(Translate(text.Substring(i, 3)));
        }

        Console.WriteLine(NumberToDecimal(number.ToString()).ToString());
    }

    static char Translate(string symbols)
    {
        switch (symbols)
        {
            case "CHU":
                return '0';
            case "TEL":
                return '1';
            case "OFT":
                return '2';
            case "IVA":
                return '3';
            case "EMY":
                return '4';
            case "VNB":
                return '5';
            case "POQ":
                return '6';
            case "ERI":
                return '7';
            case "CAD":
                return '8';
            case "K-A":
                return '9';
            case "IIA":
                return 'A';
            case "YLO":
                return 'B';
            case "PLA":
                return 'C';
            default:
                return 'D';
        }
    }

    static long NumberToDecimal(string value)
    {
        byte[] convertedValue = new byte[value.Length];

        for (int i = 0; i < convertedValue.Length; i++)
        {
            switch (value[i])
            {
                case 'A':
                    convertedValue[i] = 10;
                    break;
                case 'B':
                    convertedValue[i] = 11;
                    break;
                case 'C':
                    convertedValue[i] = 12;
                    break;
                default:
                    convertedValue[i] = byte.Parse(Convert.ToString(value[i]));
                    break;
            }
        }

        long decValue = 0;

        for (int i = 0, j = convertedValue.Length - 1; i < convertedValue.Length; i++, j--)
        {
            decValue += convertedValue[i] * (long)Math.Pow(13, j);
        }

        return decValue;
    }
}