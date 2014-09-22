/*
 * 07. We are given a matrix of passable and non-passable cells. Write a recursive program 
 * for finding all paths between two cells in the matrix.
*/
namespace FindAllPaths
{
    using System;

    public class FindAllPaths
    {
        private static char[,] labyrinth = 
        {
            { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
            { '*', '*', ' ', '*', ' ', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', '*', '*', '*', '*', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', 'E' },
        };

        private static void Main(string[] args)
        {
            FindPath(new Position(0, 0));
        }

        private static void FindPath(Position position)
        {
            if (position.Row < 0 || position.Row >= labyrinth.GetLength(0) || 
                position.Col < 0 || position.Col >= labyrinth.GetLength(1))
            {
                return;
            }

            if (labyrinth[position.Row, position.Col] == 'E')
            {
                PrintLabyrint();
            }

            if (labyrinth[position.Row, position.Col] != ' ')
            {
                return;
            }

            labyrinth[position.Row, position.Col] = 'V';

            FindPath(new Position(position.Row, position.Col - 1)); // left
            FindPath(new Position(position.Row - 1, position.Col)); // up
            FindPath(new Position(position.Row, position.Col + 1)); // right
            FindPath(new Position(position.Row + 1, position.Col)); // down

            labyrinth[position.Row, position.Col] = ' ';
        }

        private static void PrintLabyrint()
        {
            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    Console.Write(labyrinth[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}