using System;
using System.IO;
using System.Security;
using System.Text.RegularExpressions;

class RemoveListedWords
{
    static void Main()
    {
        try
        {
            Console.WriteLine("The first file location: ");
            string firstFileLocation = Console.ReadLine();

            Console.WriteLine("The second file location: ");
            string secondFileLocation = Console.ReadLine();

            string regex = @"\b(" + String.Join("|", File.ReadAllLines(secondFileLocation)) + @")\b";
            string fileContent = File.ReadAllText(firstFileLocation);
            File.WriteAllText(firstFileLocation, Regex.Replace(fileContent, regex, String.Empty, RegexOptions.IgnoreCase));

            Console.WriteLine("\nDone!");
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