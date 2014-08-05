// 4. Decode and Decrypt from C# Part 2 - 2013/2014 @ 14 Sept 2013 - Morning

using System;
using System.Text;

class DecodeAndDecrypt
{
    static void Main()
    {
        string text = Console.ReadLine();
        Decode(text);
    }

    static void Decode(string cypherText)
    {
        StringBuilder cypher = new StringBuilder();
        StringBuilder number = new StringBuilder();
        StringBuilder text = new StringBuilder();
        int k = 2;

        // the last one is always a digit
        number.Append(cypherText[cypherText.Length - 1]);

        // checks whether the number has more digits
        while (true)
        {
            if (char.IsDigit(cypherText[cypherText.Length - k]))
            {
                number.Insert(0, cypherText[cypherText.Length - k]);
                k++;
            }
            else
            {
                break;
            }
        }

        int cypherLength = int.Parse(number.ToString());
        number.Clear();
        int letterIndex;
        int endCypher = -1;

        for (int i = cypherText.Length - k; i >= 0; i--)
        {
            // checks for a digit
            if (char.IsDigit(cypherText[i]))
            {
                letterIndex = i + 1;
                number.Append(cypherText[i]);

                // checks whether the number has more digits
                while (true)
                {
                    if (char.IsDigit(cypherText[i - 1]))
                    {
                        number.Insert(0, cypherText[i - 1]);
                        i--;
                    }
                    else
                    {
                        break;
                    }
                }

                // inserts the number of the symbols - 1, because it has inserted this symbol once
                for (int j = 1; j < int.Parse(number.ToString()); j++)
                {
                    cypher.Insert(0, cypherText[letterIndex]);
                }

                number.Clear();
            }
            else
            {
                cypher.Insert(0, cypherText[i]);
            }

            // it has found the cypher
            if (cypher.Length == cypherLength)
            {
                // this is the last position of the cypher
                endCypher = i - 1;

                break;
            }
        }

        for (int i = endCypher; i >= 0; i--)
        {
            // checks for a digit
            if (char.IsDigit(cypherText[i]))
            {
                letterIndex = i + 1;
                number.Append(cypherText[i]);

                // checks whether the number has more digits
                while (true)
                {
                    if (i - 1 >= 0 && char.IsDigit(cypherText[i - 1]))
                    {
                        number.Insert(0, cypherText[i - 1]);
                        i--;
                    }
                    else
                    {
                        break;
                    }
                }

                // inserts the number of the symbols - 1, because it has inserted this symbol once
                for (int j = 1; j < int.Parse(number.ToString()); j++)
                {
                    text.Insert(0, cypherText[letterIndex]);
                }

                number.Clear();
            }
            else
            {
                text.Insert(0, cypherText[i]);
            }
        }

        Decrypt(text.ToString(), cypher.ToString());
    }

    static void Decrypt(string message, string cypher)
    {
        StringBuilder output = new StringBuilder();
        int j = 0;

        if (message.Length < cypher.Length)
        {
            for (int i = 0; i < message.Length; i++)
            {
                int current = j;
                int currentInputSymbol = message[i] - 65;
                int currentEncryptionSymbol = cypher[j] - 65;
                int result = currentInputSymbol ^ currentEncryptionSymbol;
                current += message.Length;

                while (current < cypher.Length)
                {
                    currentInputSymbol = ((char)(result + 65) - 65);
                    currentEncryptionSymbol = cypher[current] - 65;
                    result = currentInputSymbol ^ currentEncryptionSymbol;
                    current += message.Length;
                }

                output.Append((char)(result + 65));
                j++;
            }
        }
        else
        {
            for (int i = 0; i < message.Length; i++)
            {
                int currentInputSymbol = message[i] - 65;
                int currentEncryptionSymbol = cypher[j] - 65;
                int result = currentInputSymbol ^ currentEncryptionSymbol;
                output.Append((char)(result + 65));

                if (j == cypher.Length - 1)
                {
                    j = 0;
                }
                else
                {
                    j++;
                }
            }
        }

        Console.WriteLine(output.ToString());
    }
}