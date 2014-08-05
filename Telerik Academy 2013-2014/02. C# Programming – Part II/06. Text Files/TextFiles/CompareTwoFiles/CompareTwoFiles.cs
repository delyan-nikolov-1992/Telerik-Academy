using System;
using System.IO;

class CompareTwoFiles
{
    static void Main()
    {
        try
        {
            Console.WriteLine("The first file location: ");
            string fileLocation = Console.ReadLine();
            StreamReader firstReader = new StreamReader(fileLocation);

            Console.WriteLine("The second file location: ");
            fileLocation = Console.ReadLine();
            StreamReader secondReader = new StreamReader(fileLocation);

            int same = 0;
            int different = 0;

            using (firstReader)
            {
                using (secondReader)
                {
                    string firstReaderLine = firstReader.ReadLine();
                    string secondReaderLine = secondReader.ReadLine();

                    while (firstReaderLine != null)
                    {
                        if (firstReaderLine.Equals(secondReaderLine))
                        {
                            same++;
                        }
                        else
                        {
                            different++;
                        }

                        firstReaderLine = firstReader.ReadLine();
                        secondReaderLine = secondReader.ReadLine();
                    }
                }
            }

            Console.WriteLine("\nThe number of lines that are the same: {0}", same);
            Console.WriteLine("The number of lines that are different: {0}", different);
        }
        catch
        {
            Console.WriteLine("Fatal error occurred.");
        }
    }
}