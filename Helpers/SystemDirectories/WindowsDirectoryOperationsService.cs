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
                    //TODO: MessageBox
                }
            }
        }

        public static void CreateDirectory(string path, string name)
        {
            string fullPath = path + "\\" + name;
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
        }

        public static void MoveDirectory(string sourcePath, string destinationPath)
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

        public static void CopyDirectory(string sourcePath, string destinationPath)
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

        private static void DirectoryCopy(string sourcePath, string destinationPath)
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
    }
}
