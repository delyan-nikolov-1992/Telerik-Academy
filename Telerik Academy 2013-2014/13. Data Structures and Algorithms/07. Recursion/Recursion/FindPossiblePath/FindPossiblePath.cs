/*
 * 08. Modify the above program to check whether a path exists between two cells 
 * without finding all possible paths. Test it over an empty 100 x 100 matrix.
*/
namespace FindPossiblePath
{
    using System;

    public class FindPossiblePath
    {
        private static void Main(string[] args)
        {
            char[,] labyrinth = GenerateEmptyLabyrinth(100, 100);
            SetExit(labyrinth, new Position(60, 60));
            bool foundPath = false;

            FindPath(labyrinth, new Position(0, 0), ref foundPath);

            PrintResult(ref foundPath);
        }

        private static void FindPath(char[,] labyrinth, Position position, ref bool foundPath)
        {
            if (foundPath || position.Row < 0 || position.Row >= labyrinth.GetLength(0) || position.Col < 0 || position.Col >= labyrinth.GetLength(1))
            {
                return;
            }

            if (labyrinth[position.Row, position.Col] == 'E')
            {
                foundPath = true;
            }

            if (labyrinth[position.Row, position.Col] != ' ')
            {
                return;
            }

            labyrinth[position.Row, position.Col] = 'V';

            FindPath(labyrinth, new Position(position.Row, position.Col - 1), ref foundPath); // left
            FindPath(labyrinth, new Position(position.Row - 1, position.Col), ref foundPath); // up
            FindPath(labyrinth, new Position(position.Row, position.Col + 1), ref foundPath); // right
            FindPath(labyrinth, new Position(position.Row + 1, position.Col), ref foundPath); // down

            labyrinth[position.Row, position.Col] = ' ';
        }

        private static char[,] GenerateEmptyLabyrinth(int rows, int cols)
        {
            char[,] labyrinth = new char[rows, cols];

            for (int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    labyrinth[i, j] = ' ';
                }
            }

            return labyrinth;
        }

        private static void SetExit(char[,] labyrinth, Position position)
        {
            labyrinth[position.Row, position.Col] = 'E';
        }

        private static void PrintResult(ref bool foundPath)
        {
            if (foundPath)
            {
                Console.WriteLine("There is an existing path!");
            }
            else
            {
                Console.WriteLine("There is no existing path!");
            }
        }
    }
}