using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.SystemDirectories
{
    public class WindowsDirectoryOperationsService
    {
        public static void DeleteDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                try
                {

                    Directory.Delete(path, true);
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error has occured: " + e.Message);
                }
            }
        }

        public static void CreateDirectory(string path, string name)
        {
            string fullPath = path + "\\" + name;
            try
            {
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has occured: " + e.Message);
            }

        }

        public static void MoveDirectory(string sourcePath, string destinationPath)
        {
            try
            {
                if (!sourcePath.Equals(destinationPath))
                {
                    if (Directory.Exists(destinationPath))
                    {
                        return;
                    }
                    Directory.Move(sourcePath, destinationPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has occured: " + e.Message);
            }

        }

        public static void CopyDirectory(string sourcePath, string destinationPath)
        {
            try
            {
                if (!sourcePath.Equals(destinationPath))
                {
                    if (Directory.Exists(destinationPath))
                    {
                        return;
                    }
                    DirectoryCopy(sourcePath, destinationPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has occured: " + e.Message);
            }
        }

        private static void DirectoryCopy(string sourcePath, string destinationPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(sourcePath);

                if (!dir.Exists)
                {
                    return;
                }
                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }

                DirectoryInfo[] dirs = dir.GetDirectories();

                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    string tempPath = Path.Combine(destinationPath, file.Name);
                    file.CopyTo(tempPath, false);
                }

                foreach (DirectoryInfo subDir in dirs)
                {
                    string tempPath = Path.Combine(destinationPath, subDir.Name);
                    DirectoryCopy(subDir.FullName, tempPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has occured: " + e.Message);
            }
        }
    }
}
