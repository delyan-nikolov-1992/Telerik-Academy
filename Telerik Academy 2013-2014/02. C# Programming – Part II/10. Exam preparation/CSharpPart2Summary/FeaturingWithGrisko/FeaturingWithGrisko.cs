// 5. Featuring with Grisko from C# Part 2 - 2013/2014 @ 14 Sept 2013 - Morning

using System;

class FeaturingWithGrisko
{
    static void Main(string[] args)
    {
        string s = Console.ReadLine();
        char[] buffer = s.ToCharArray();
        sortchar(buffer, buffer.Length);
        int count = 0;

        while (true)
        {
            bool result = false;

            for (int i = 0; i < buffer.Length - 1; i++)
            {
                if (buffer[i] == buffer[i + 1])
                {
                    result = true;
                    break;
                }
            }

            if (!result)
            {
                count++;
            }

            if (NextPermuation(buffer, buffer.Length) == false)
            {
                break;
            }
        }

        Console.WriteLine(count);
    }

    static void sortchar(char[] word, int size)
    {
        for (int i = 1; i < size; i++)
        {
            for (int j = 0; j < size - i; j++)
            {
                if (word[j] > word[j + 1])
                {
                    char temp = word[j];
                    word[j] = word[j + 1];
                    word[j + 1] = temp;
                }
            }
        }
    }

    static bool NextPermuation(char[] word, int size)
    {
        for (int i = size - 1; i > 0; i--)
        {
            if (word[i - 1] >= word[i])
            {
                continue;
            }
            else
            {
                if (i <= size - 3)
                {
                    char temp = word[i - 1];
                    int anchor = -1;

                    for (int j = size - 1; j >= i; j--)
                    {
                        if (temp < word[j])
                        {
                            anchor = j;
                            break;
                        }
                    }
                    if (anchor == -1)
                    {
                        return false;
                    }

                    char previous = word[i - 1];
                    word[i - 1] = word[anchor];
                    word[anchor] = previous;
                    char[] newWord = new char[size - i];

                    for (int k = 0; k < size - i; k++)
                    {
                        newWord[k] = word[i + k];
                    }

                    sortchar(newWord, size - i);

                    for (int l = 0; l < size - i; l++)
                    {
                        word[i + l] = newWord[l];
                    }

                    return true;
                }
                else
                {
                    char[] tempWord = new char[3];
                    tempWord[0] = word[word.Length - 3];
                    tempWord[1] = word[word.Length - 2];
                    tempWord[2] = word[word.Length - 1];
                    int count = 3;

                    for (int j = count - 1; j > 0; j--)
                    {
                        if (tempWord[j - 1] >= tempWord[j])
                        {
                            continue;
                        }
                        else
                        {
                            if (j <= count - 2)
                            {
                                if (tempWord[j + 1] > tempWord[j - 1])
                                {
                                    char next = tempWord[j + 1];
                                    tempWord[j + 1] = tempWord[j];
                                    tempWord[j] = tempWord[j - 1];
                                    tempWord[j - 1] = next;
                                }
                                else
                                {
                                    char previous = tempWord[j - 1];
                                    tempWord[j - 1] = tempWord[j];
                                    tempWord[j] = tempWord[j + 1];
                                    tempWord[j + 1] = previous;
                                }
                            }
                            else
                            {
                                char current = tempWord[j];
                                tempWord[j] = tempWord[j - 1];
                                tempWord[j - 1] = current;
                            }

                            word[word.Length - 3] = tempWord[0];
                            word[word.Length - 2] = tempWord[1];
                            word[word.Length - 1] = tempWord[2];

                            return true;
                        }
                    }

                    return false;
                }
            }
        }

        return false;
    }
}