using System;
using System.IO;
using System.Net;
using System.Security;

class DownloadFile
{
    static void Main()
    {
        WebClient webClient = new WebClient();

        try
        {
            Console.WriteLine("The URL of the file to be downloaded:");
            Uri uri = new Uri(Console.ReadLine());
            string fileName = System.IO.Path.GetFileName(uri.LocalPath);
            webClient.DownloadFile(uri, fileName);
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
        finally
        {
            webClient.Dispose();
        }
    }
}