namespace Minesweepers
{
    using System;
    using System.Collections.Generic;

    public class Engine
    {
        public static void Main(string[] args)
        {
            const int MAX_BOXES = 35;

            string command = string.Empty;
            char[,] field = CreateField();
            char[,] mines = SetMines();
            int points = 0;
            bool isMine = false;
            List<Player> champions = new List<Player>(6);
            int row = 0;
            int col = 0;
            bool hasEnded = true;
            bool hasStarted = false;

            do
            {
                if (hasEnded)
                {
                    Console.WriteLine("Let's play Minesweepers. Find the boxes without mines. " +
                        "Command 'top' shows the current standings, 'restart' restarts the game, 'exit' exits!");
                    PrintField(field);
                    hasEnded = false;
                }

                Console.Write("Position (row and col): ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Standings(champions);
                        break;
                    case "restart":
                        field = CreateField();
                        mines = SetMines();
                        PrintField(field);
                        isMine = false;
                        hasEnded = false;
                        break;
                    case "exit":
                        Console.WriteLine("Game Over!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                OnMove(field, mines, row, col);
                                points++;
                            }

                            if (points == MAX_BOXES)
                            {
                                hasStarted = true;
                            }
                            else
                            {
                                PrintField(field);
                            }
                        }
                        else
                        {
                            isMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command\n");
                        break;
                }

                if (isMine)
                {
                    PrintField(mines);
                    Console.Write("\nGame over! You made {0} points. Nickname: ", points);
                    string nickname = Console.ReadLine();
                    Player player = new Player(nickname, points);

                    if (champions.Count < 5)
                    {
                        champions.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < player.Points)
                            {
                                champions.Insert(i, player);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Player firstPlayer, Player secondPlayer) =>
                        secondPlayer.Name.CompareTo(firstPlayer.Name));
                    champions.Sort((Player firstPlayer, Player secondPlayer) =>
                        secondPlayer.Points.CompareTo(firstPlayer.Points));
                    Standings(champions);

                    field = CreateField();
                    mines = SetMines();
                    points = 0;
                    isMine = false;
                    hasEnded = true;
                }

                if (hasStarted)
                {
                    Console.WriteLine("\nCongratulations! You have opened all 35 boxes.");
                    PrintField(mines);
                    Console.WriteLine("Nickname: ");
                    string nickname = Console.ReadLine();
                    Player player = new Player(nickname, points);
                    champions.Add(player);
                    Standings(champions);
                    field = CreateField();
                    mines = SetMines();
                    points = 0;
                    hasStarted = false;
                    hasEnded = true;
                }
            }
            while (command != "exit");
        }

        private static void Standings(List<Player> players)
        {
            Console.WriteLine("\nPlayers:");

            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, players[i].Name, players[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty box!\n");
            }
        }

        private static void OnMove(char[,] field, char[,] mines, int row, int col)
        {
            char nearbyMines = NearbyMines(mines, row, col);
            mines[row, col] = nearbyMines;
            field[row, col] = nearbyMines;
        }

        private static void PrintField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < cols; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateField()
        {
            int rows = 5;
            int cols = 10;
            char[,] board = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] SetMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] field = new char[rows, cols];
            List<int> listOfMines = new List<int>();
            Random randomGenerator = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = '-';
                }
            }

            while (listOfMines.Count < 15)
            {
                int mine = randomGenerator.Next(50);

                if (!listOfMines.Contains(mine))
                {
                    listOfMines.Add(mine);
                }
            }

            foreach (int mine in listOfMines)
            {
                int col = mine / cols;
                int row = mine % cols;

                if (row == 0 && mine != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                field[col, row - 1] = '*';
            }

            return field;
        }

        private static char NearbyMines(char[,] field, int row, int col)
        {
            int nearbyMines = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    nearbyMines++;
                }
            }

            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    nearbyMines++;
                }
            }

            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    nearbyMines++;
                }
            }

            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                {
                    nearbyMines++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    nearbyMines++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    nearbyMines++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    nearbyMines++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    nearbyMines++;
                }
            }

            return char.Parse(nearbyMines.ToString());
        }

        private class Player
        {
            private string name;
            private int points;

            public Player(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }

            public string Name
            {
                get { return this.name; }
                set { this.name = value; }
            }

            public int Points
            {
                get { return this.points; }
                set { this.points = value; }
            }
        }
    }
}
