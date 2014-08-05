using System;
using System.IO;

class MatrixMaxSum
{
    static void Main()
    {
        try
        {
            Console.WriteLine("The input file location: ");
            string fileLocation = Console.ReadLine();
            StreamReader reader = new StreamReader(fileLocation);

            Console.WriteLine("The output file location: ");
            fileLocation = Console.ReadLine();
            StreamWriter writer = new StreamWriter(fileLocation);

            using (reader)
            {
                using (writer)
                {
                    string line = reader.ReadLine();
                    int size = int.Parse(line);
                    int[,] matrix = new int[size, size];
                    int counter = 0;
                    line = reader.ReadLine();

                    while (line != null)
                    {
                        string[] words = line.Split(' ');

                        for (int i = 0; i < words.Length; i++)
                        {
                            matrix[counter, i] = int.Parse(words[i]);
                        }

                        counter++;
                        line = reader.ReadLine();
                    }

                    int bestSum = int.MinValue;

                    for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                        {
                            int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

                            if (sum > bestSum)
                            {
                                bestSum = sum;
                            }
                        }
                    }

                    writer.Write(bestSum);
                }
            }

            Console.WriteLine("\nDone!");
        }
        catch
        {
            Console.WriteLine("Fatal error occurred.");
        }
    }
}