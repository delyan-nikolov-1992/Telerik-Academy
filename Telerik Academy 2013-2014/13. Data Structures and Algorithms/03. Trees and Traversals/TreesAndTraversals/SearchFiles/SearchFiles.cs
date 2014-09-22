/*
 * 02. Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively 
 * and to display all files matching the mask *.exe. Use the class System.IO.Directory.
*/
namespace SearchFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class SearchFiles
    {
        // searching in "C:\WINDOWS" is very slow, but you can try it
        private const string DirectoryToBeSearched = @"C:\WINDOWS\WinSxS";
        private const string MaskToBeSearched = ".exe";

        public static HashSet<string> allSearchedFiles = new HashSet<string>();

        public static void Main()
        {
            DFS(DirectoryToBeSearched);

            foreach (var file in allSearchedFiles)
            {
                Console.WriteLine(file);
            }
        }

        private static void DFS(string dirToSearch)
        {
            try
            {
                foreach (string file in Directory.GetFiles(dirToSearch))
                {
                    if (file.EndsWith(MaskToBeSearched))
                    {
                        allSearchedFiles.Add(file);
                    }
                }

                foreach (string dir in Directory.GetDirectories(dirToSearch))
                {
                    DFS(dir);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}