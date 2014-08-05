using System;

class LettersInWord
{
    static void Main()
    {
        try
        {
            Console.Write("Type one word: ");
            string word = Console.ReadLine();

            char[] letters = new char[52];

            for (int i = 0; i < 52; i++)
            {
                if (i < 26)
                {
                    letters[i] = (char)(65 + i);
                }
                else
                {
                    letters[i] = (char)(71 + i);
                }
            }

            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < 52; j++)
                {
                    if (word[i] == letters[j])
                    {
                        Console.WriteLine("The index of the letter {0} in the array is {1}", word[i], j);
                    }
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Wrong input!");
        }
    }
}