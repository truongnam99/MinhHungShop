using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class FileHelpers
    {
        public static void copy(string sourcePath, string targetPath, string sourceName, string targetName)
        {
            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, sourceName);
            string destFile = System.IO.Path.Combine(targetPath, targetName);

            // To copy a folder's contents to a new location:
            // Create a new target folder.
            // If the directory already exists, this method does not create a new directory.
            System.IO.Directory.CreateDirectory(targetPath);

            // To copy a file to another location and
            // overwrite the destination file if it already exists.
            System.IO.File.Copy(sourceFile, destFile, true);

            // To copy all the files in one directory to another directory.
            // Get the files in the source folder. (To recursively iterate through
            // all subfolders under the current directory, see
            // "How to: Iterate Through a Directory Tree.")
            // Note: Check for target path was performed previously
            //       in this code example.
            if (System.IO.Directory.Exists(sourcePath))
            {
                System.IO.File.Copy(sourceFile, destFile, true);
                Console.WriteLine("Copy successful!");

            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }
    }
}
