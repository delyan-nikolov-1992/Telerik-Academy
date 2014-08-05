using System;
using System.IO;
using System.Threading;

class Shell
{
    static void Main()
    {
        Console.WindowWidth = 168;
        Console.WindowHeight = 58;
        
        Console.BufferWidth = 168;
        Console.BufferHeight = 61;

        try
        {
            Monopoly game = new Monopoly();

            game.DrawMatrix(40, 0);

            while (game.Players.Count > 1)
            {
                for (int i = 0; i < game.Players.Count; i++)
                {
                    game.ThrowDice(game.Players[i], 0);
                    //Console.WriteLine("The player is : " + i);
                }
            }

            Console.Clear();
            Console.WriteLine("Congratulations!");
            Console.WriteLine("The winner is {0} with money {1}.", game.Players[0].Color, game.Players[0].Cash);

            //Console.WriteLine(10%10);

            //Random numGen = new Random();
            //Monopoly monopoly = new Monopoly();

            //int firstDice = numGen.Next(1, 7);
            //int secondDice = numGen.Next(1, 7);

            //for (int i = 0; i < 4; i++)
            //{

            //}
            //Console.WriteLine(firstDice);
            //Console.WriteLine(secondDice);
            //Console.WriteLine(monopoly.Players[0].CurrentPosition);
            //monopoly.Players[0].CurrentPosition = (byte)(firstDice + secondDice);
            //Console.WriteLine(monopoly.Players[0].CurrentPosition);

            //while (monopoly.Players.Count > 1)
            //{
            //    for (int i = 0; i < monopoly.Players.Count; i++)
            //    {
            //        ThrowDice(monopoly.Players[i], 0);
            //    }
            //}

            //monopoly.PrintBoard();
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory not found!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found!");
        }
        catch (IOException)
        {
            Console.WriteLine("Input/Output error!");
        }
    }

    static char[,] FillPropertyCardMatrix(string pathToFile)
    {
        char[,] matrix = new char[44, 39];
        StreamReader inputMatrix = new StreamReader(pathToFile);

        using (inputMatrix)
        {
            string line;
            string[] matrixStrRow = new string[39];

            for (int i = 0; i < 44; i++)
            {
                line = inputMatrix.ReadLine();
                string[] sep = new string[] { "  " };
                matrixStrRow = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < 39; j++)
                {
                    matrix[i, j] = Convert.ToChar(matrixStrRow[j]);
                }
            }
        }

        return matrix;
    }

    static void PrintPropertyCardMatrix(char[,] gameField)
    {
        for (int i = 0; i < gameField.GetLength(0); i++)
        {
            Console.SetCursorPosition(10, 5 + i);

            for (int j = 0; j < gameField.GetLength(1); j++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Gray;

                switch (gameField[i, j])
                {
                    case '@':
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case '#':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case '$':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case '%':
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case '^':
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case '*':
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case '(':
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case ')':
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case '&':
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case '+':
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    default:
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }

                Console.Write(gameField[i, j]);
            }

            Console.WriteLine();
        }
    }


}
