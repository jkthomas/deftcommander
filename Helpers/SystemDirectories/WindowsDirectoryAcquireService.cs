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

        public static List<string> GetDirectoryParentTree(string path)
        {
            string parent;
            try
            {
                parent = Directory.GetParent(path).ToString();
                if (parent.Length == 3)
                {
                    return Directory.GetLogicalDrives().ToList();
                }
            }
            catch (Exception e)
            {
                return Directory.GetLogicalDrives().ToList();
            }

            parent = Directory.GetParent(parent).ToString();
            if (parent.Length == 3)
            {
                return Directory.GetLogicalDrives().ToList();
            }

            return Directory.EnumerateFileSystemEntries(parent).ToList();
        }
    }
}
