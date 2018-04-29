using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.SystemDirectories
{
    public class WindowsDirectoryAcquireService
    {
        public static List<string> GetComputerDrives()
        {
            var drives = Directory.GetLogicalDrives().ToList();

            return drives;
        }

        public static List<string> GetDirectoryFolders(string path)
        {
            var dirs = Directory.EnumerateDirectories(path).ToList();
            if (dirs.Equals(null))
            {
                throw new Exception("Empty directory");
            }

            return dirs;
        }

        public static List<string> GetDirectoryFiles(string path)
        {
            var files = Directory.EnumerateFiles(path).ToList();
            if (files.Equals(null))
            {
                throw new Exception("Empty directory");
            }
            return files;
        }

        public static List<string> GetDiretoryTree(string path)
        {
            var tree = Directory.EnumerateFileSystemEntries(path).ToList();
            if (tree.Equals(null))
            {
                throw new Exception("Empty directory");
            }
            return tree;
        }

        public static List<string> GetDirectoryParent(string path)
        {
            string parent = Directory.GetParent(path).ToString();
            if (parent.Count() == 4)
            {
                return Directory.GetLogicalDrives().ToList();
            }

            return Directory.EnumerateFileSystemEntries(parent).ToList();
        }
    }
}
