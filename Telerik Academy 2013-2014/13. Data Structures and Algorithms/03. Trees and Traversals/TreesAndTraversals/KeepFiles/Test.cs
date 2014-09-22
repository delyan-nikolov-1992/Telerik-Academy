/*
 * 03. Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders } 
 * and using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS. 
 * Implement a method that calculates the sum of the file sizes in given subtree of the tree and test it 
 * accordingly. Use recursive DFS traversal.
*/
namespace KeepFiles
{
    using System;
    using System.IO;

    public class Test
    {
        // searching in "C:\WINDOWS" is very slow, but you can try it
        private const string StartFolder = @"C:\WINDOWS\Help";

        public static void Main()
        {
            var root = new Folder(StartFolder);

            FillFolderWithFiles(new DirectoryInfo(StartFolder), root);

            PrintFromFolder(root, 0);

            Console.WriteLine("Total size is {0} bytes", root.GetSize());
        }

        public static void FillFolderWithFiles(DirectoryInfo dir, Folder folder)
        {
            try
            {
                foreach (FileInfo file in dir.GetFiles())
                {
                    folder.Files.Add(new File(file.Name, file.Length));
                }

                foreach (var subDir in dir.GetDirectories())
                {
                    var subFolder = new Folder(subDir.Name);
                    folder.SubFolders.Add(subFolder);
                    FillFolderWithFiles(subDir, subFolder);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintFromFolder(Folder folder, int offset)
        {
            Console.Write(new string('-', offset) + folder.Name);

            if (offset == 0)
            {
                Console.Write(" <- (root)");
            }

            Console.WriteLine();

            foreach (var subfolder in folder.SubFolders)
            {
                PrintFromFolder(subfolder, offset + 2);
            }

            foreach (var file in folder.Files)
            {
                Console.WriteLine(new string('-', offset) + file.Name);
            }
        }
    }
}