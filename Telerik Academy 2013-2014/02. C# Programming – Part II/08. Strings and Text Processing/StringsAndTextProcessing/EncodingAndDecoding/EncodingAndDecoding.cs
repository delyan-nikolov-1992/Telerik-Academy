using System;
using System.Text;

class EncodingAndDecoding
{
    static void Main()
    {
        Console.Write("The string to be encoded: ");
        string input = Console.ReadLine();
        Console.Write("The encryption key: ");
        string encryptionKey = Console.ReadLine();

        Console.WriteLine("The encoded string: \n{0}", Encrypt(input, encryptionKey));
        Console.WriteLine("\nThe decoded string: \n{0}", Encrypt(Encrypt(input, encryptionKey), encryptionKey));
    }

    static string Encrypt(string input, string encryptionKey)
    {
        StringBuilder output = new StringBuilder();
        int j = 0;

        for (int i = 0; i < input.Length; i++)
        {
            int currentInputSymbol = (int)(input[i]);
            int currentEncryptionSymbol = (int)(encryptionKey[j]);
            int result = currentInputSymbol ^ currentEncryptionSymbol;

            output.Append((char)result);

            if (j == encryptionKey.Length - 1)
            {
                j = 0;
            }
            else
            {
                j++;
            }
        }

        return output.ToString();
    }
}