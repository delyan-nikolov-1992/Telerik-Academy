
    public static void PrintCard(byte inPos)
    {
        string fileName =  "converted/" + Convert.ToString(inPos) + ".txt";
        char[,] charMatrix = new char[44, 39];

        StreamReader inputMatrix = new StreamReader(fileName);

        using (inputMatrix)
        {
            string line;
            string[] matrixStrRow = new string[39];

            for (int i = 0; i < 44; i++)
            {
                line = inputMatrix.ReadLine();
                string[] sep = new string[] { " " };
                matrixStrRow = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < 39; j++)
                {
                    charMatrix[i, j] = Convert.ToChar(matrixStrRow[j]);
                }
            }
        }

        for (int i = 0; i < charMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < charMatrix.GetLength(1); j++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Gray;

                switch (charMatrix[i, j])
                {
                    case ')':
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case '@':
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case '%':
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case '$':
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case '#':
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case '*':
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case '^':
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case '(':
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case '`':
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case '~':
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                    case '&':
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case '-':
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case '>':
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case '<':
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    default:
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }

                Console.Write(charMatrix[i, j]);
            }

            Console.WriteLine();
        }
    }