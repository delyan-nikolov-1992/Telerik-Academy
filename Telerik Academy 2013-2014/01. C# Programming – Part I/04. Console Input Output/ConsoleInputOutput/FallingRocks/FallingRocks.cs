using System;
using System.Collections.Generic;
using System.Threading;

class FallingRocks
{
    static void Main()
    {
        int lives = 3;
        int score = 0;
        bool hit = false;
        string[] symbolList = { "^", "@", "*", "&", "+", "%", "$", "#", "!", ".", ";" };
        List<Unit> rocks = new List<Unit>();
        Random randomGenerator = new Random();
        Unit dwarf = new Unit();

        dwarf.x = (Console.WindowWidth / 2) - 1;
        dwarf.y = Console.WindowHeight - 1;
        dwarf.color = ConsoleColor.White;
        dwarf.symbol = "(0)";

        SetGameField();

        while (lives > 0)
        {
            Unit newRock = new Unit();

            newRock.x = randomGenerator.Next(0, Console.WindowWidth - 1);
            newRock.y = 0;
            newRock.color = (ConsoleColor)randomGenerator.Next((int)ConsoleColor.Blue, (int)ConsoleColor.White);
            newRock.symbol = symbolList[randomGenerator.Next(0, 10)];

            rocks.Add(newRock);

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (dwarf.x > 0)
                    {
                        dwarf.x--;
                    }
                }

                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (dwarf.x < Console.WindowWidth - 4)
                    {
                        dwarf.x++;
                    }
                }
            }

            List<Unit> newRocks = new List<Unit>();

            foreach (Unit rock in rocks)
            {
                Unit currentRock = rock;
                currentRock.y += 1;

                if ((currentRock.x == dwarf.x || currentRock.x == dwarf.x + 1 || currentRock.x == dwarf.x + 2)
                    && currentRock.y == dwarf.y)
                {
                    lives--;
                    hit = true;
                }

                if (currentRock.y < Console.WindowHeight)
                {
                    newRocks.Add(currentRock);
                }
                else
                {
                    score++;
                }
            }

            rocks = newRocks;

            Console.Clear();

            if (hit)
            {
                WriteOnPosition(dwarf.x, dwarf.y, "(X)", dwarf.color);
                dwarf.x = (Console.WindowWidth / 2) - 1;
                dwarf.y = Console.WindowHeight - 1;
                rocks.Clear();
                hit = false;
            }
            else
            {
                WriteOnPosition(dwarf.x, dwarf.y, dwarf.symbol, dwarf.color);
            }

            foreach (Unit rock in rocks)
            {
                WriteOnPosition(rock.x, rock.y, rock.symbol, rock.color);
            }

            WriteOnPosition(0, 0, "Lives: " + lives, ConsoleColor.White);
            WriteOnPosition(0, 1, "Score: " + score, ConsoleColor.White);

            Thread.Sleep(150);
        }

        WriteOnPosition(0, 2, "GAME OVER!\n", ConsoleColor.White);
    }

    struct Unit
    {
        public int x;
        public int y;
        public ConsoleColor color;
        public string symbol;
    }

    static void SetGameField()
    {
        Console.WindowHeight = 30;
        Console.BufferHeight = 30;
        Console.WindowWidth = 100;
        Console.BufferWidth = 100;
    }

    static void WriteOnPosition(int x, int y, string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(x, y);
        Console.Write(text);
    }
}