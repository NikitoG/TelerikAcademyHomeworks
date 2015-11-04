namespace TraverseDirectory
{
    using System;
    using System.IO;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            TraverseDirectory("C:\\WINDOWS");
        }

        private static void TraverseDirectory(string path)
        {
            try
            {
                var directory = new DirectoryInfo(path);
                Console.WriteLine(directory.FullName);

                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    if (file.EndsWith(".exe"))
                    {
                        Console.WriteLine(file);
                    }
                }

                foreach (var subDirectory in directory.GetDirectories())
                {
                    TraverseDirectory(subDirectory.FullName);
                }
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }
        }
    }
}
