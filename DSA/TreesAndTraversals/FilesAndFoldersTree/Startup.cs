namespace FilesAndFoldersTree
{
    using System;
    using System.IO;
    using System.Linq;

    public class Program
    {
        private static Folder mainFolder = new Folder("WINDOWS");

        public static void Main()
        {
            GetAllFilesAndFoldersInGivenDirectory(new DirectoryInfo(@"C:\WINDOWS"), mainFolder);
            ulong sum = 0;
            sum = CalculateSumOfFileSizeInSubTree(mainFolder, sum);
            Console.WriteLine("Sum of the size in given subtree: {0}", sum);
        }

        private static ulong CalculateSumOfFileSizeInSubTree(Folder folder, ulong sum)
        {
            foreach (var file in folder.Files)
            {
                sum += (ulong)file.Size;
            }

            foreach (var subFolder in folder.ChildFolder)
            {
                sum += CalculateSumOfFileSizeInSubTree(subFolder, sum);
            }

            return sum;
        }

        private static void GetAllFilesAndFoldersInGivenDirectory(DirectoryInfo directory, Folder folder)
        {
            try
            {
                var files = directory.GetFiles();
                foreach (var file in files)
                {
                    var myFile = new File();
                    myFile.Name = file.Name;
                    myFile.Size = file.Length;

                    folder.Files.Add(myFile);
                }

                var directories = directory.GetDirectories();
                foreach (var dir in directories)
                {
                    var newFolder = new Folder(dir.Name);

                    GetAllFilesAndFoldersInGivenDirectory(dir, newFolder);

                    folder.ChildFolder.Add(newFolder);
                }
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
        }
    }
}
