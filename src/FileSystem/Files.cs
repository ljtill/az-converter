using System;
using System.IO;

namespace Microsoft.Azure.Converter.FileSystem
{
    class Files
    {
        public static FileInfo[] FindFiles(string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            FileInfo[] files = null;

            Console.WriteLine("Retrieving files");
            try
            {
                if (!info.Exists)
                {
                    Console.WriteLine("Unable to locate directory");
                    Environment.Exit(1);
                }

                files = info.GetFiles();
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }

            return files;
        }
    }
}
