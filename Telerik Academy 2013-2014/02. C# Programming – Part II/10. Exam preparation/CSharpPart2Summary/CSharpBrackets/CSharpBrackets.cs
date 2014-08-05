// 4. C# Brackets from C# Part 2 - 2012/2013 @ 5 Feb 2013

using System;
using System.Text;
using System.Text.RegularExpressions;

class CSharpBrackets
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        string begin = Console.ReadLine();
        string[] code = new string[size];

        for (int i = 0; i < code.Length; i++)
        {
            code[i] = Console.ReadLine().Trim();
        }

        ConvertCode(begin, code);
    }

    static void ConvertCode(string begin, string[] code)
    {
        StringBuilder result = new StringBuilder();
        StringBuilder indentation = new StringBuilder();

        for (int i = 0; i < code.Length; i++)
        {
            if (!string.IsNullOrWhiteSpace(code[i]))
            {
                for (int j = 0; j < code[i].Length; j++)
                {
                    switch (code[i][j])
                    {
                        case '{':
                            if (j > 0 && ((!(code[i][j - 1].Equals('{'))) && (!(code[i][j - 1].Equals('}')))))
                            {
                                result.Append('\n');
                            }

                            if (!string.IsNullOrEmpty(indentation.ToString()))
                            {
                                result.Append(indentation.ToString());
                            }

                            result.Append(code[i][j]);
                            indentation.Append(begin);

                            if (j + 1 < code[i].Length)
                            {
                                do
                                {
                                    if (code[i][j + 1].Equals(' '))
                                    {
                                        j++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                } while (true);

                                result.Append('\n');

                                if (((!(code[i][j + 1].Equals('{'))) && (!(code[i][j + 1].Equals('}'))))
                                    && (!string.IsNullOrEmpty(indentation.ToString())))
                                {
                                    result.Append(indentation.ToString());
                                }
                            }

                            break;
                        case '}':
                            if (j > 0 && ((!(code[i][j - 1].Equals('{'))) && (!(code[i][j - 1].Equals('}')))))
                            {
                                result.Append('\n');
                            }

                            indentation.Remove(0, begin.Length);

                            if (!string.IsNullOrEmpty(indentation.ToString()))
                            {
                                result.Append(indentation.ToString());
                            }

                            result.Append(code[i][j]);

                            if (j + 1 < code[i].Length)
                            {
                                do
                                {
                                    if (code[i][j + 1].Equals(' '))
                                    {
                                        j++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                } while (true);

                                result.Append('\n');

                                if (((!(code[i][j + 1].Equals('{'))) && (!(code[i][j + 1].Equals('}'))))
                                    && (!string.IsNullOrEmpty(indentation.ToString())))
                                {
                                    result.Append(indentation.ToString());
                                }
                            }

                            break;
                        case ' ':
                            do
                            {
                                if (code[i][j + 1].Equals(' '))
                                {
                                    j++;
                                }
                                else
                                {
                                    break;
                                }
                            } while (true);

                            if ((!(code[i][j + 1].Equals('{'))) && (!(code[i][j + 1].Equals('}'))))
                            {
                                result.Append(' ');
                            }

                            break;
                        default:
                            if (j == 0)
                            {
                                if ((!string.IsNullOrEmpty(indentation.ToString())))
                                {
                                    result.Append(indentation.ToString());
                                }
                            }

                            result.Append(code[i][j]);

                            break;
                    }
                }

                result.Append('\n');
            }
        }

        Console.Write(Regex.Replace(result.ToString(), "\n+", "\n"));
    }
}