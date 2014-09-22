/*
 * 10. We are given a matrix of passable and non-passable cells. Write a recursive program 
 * for finding all areas of passable cells in the matrix.
*/
namespace AllAreasOfEmptyCells
{
    using System;
    using System.Collections.Generic;

    public class AllAreasOfEmptyCells
    {
        private static char[,] labyrinth = 
        {
            { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
            { '*', '*', '*', '*', ' ', '*', ' ' },
            { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
            { ' ', '*', '*', '*', '*', '*', ' ' },
            { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
        };

        private static ICollection<Position> currentPath = new HashSet<Position>();

        private static void Main(string[] args)
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    if (labyrinth[i, j] == ' ')
                    {
                        currentPath.Clear();
                        FindPath(new Position(i, j));
                        PrintResult();
                    }
                }
            }
        }

        private static void FindPath(Position position)
        {
            if (position.Row < 0 || position.Row >= labyrinth.GetLength(0) ||
                position.Col < 0 || position.Col >= labyrinth.GetLength(1))
            {
                return;
            }

            if (labyrinth[position.Row, position.Col] != ' ')
            {
                return;
            }

            currentPath.Add(position);
            labyrinth[position.Row, position.Col] = '*';

            FindPath(new Position(position.Row, position.Col - 1)); // left
            FindPath(new Position(position.Row - 1, position.Col)); // up
            FindPath(new Position(position.Row, position.Col + 1)); // right
            FindPath(new Position(position.Row + 1, position.Col)); // down
        }

        private static void PrintResult()
        {
            Console.WriteLine(string.Join(" -> ", currentPath));
            Console.WriteLine();
        }
    }
}