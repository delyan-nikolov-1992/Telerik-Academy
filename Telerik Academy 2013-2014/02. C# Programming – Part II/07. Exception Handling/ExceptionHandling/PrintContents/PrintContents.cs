using System;
using System.IO;
using System.Security;

class PrintContents
{
    static void Main()
    {
        try
        {
            Console.WriteLine("The file location:");
            string fileLocation = Console.ReadLine();
            string contents = File.ReadAllText(fileLocation);
            Console.WriteLine("\n" + contents);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory not found!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found!");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Please enter valid file path!");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Please enter valid file path!");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("The file path must not be longer than 248 characters!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("File access error!");
        }
        catch (SecurityException)
        {
            Console.WriteLine("You don't have permission to access this file!");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Invalid path!");
        }
        catch (IOException)
        {
            Console.WriteLine("Input/Output error!");
        }
    }
}