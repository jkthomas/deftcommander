using Data.Directories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappers
{
    public class DirectoryMapper
    {
        public static DirectoryItem ToDirectoryItem(string directoryPath)
        {
            DirectoryItem directoryItem = new DirectoryItem()
            {
                DirPath = directoryPath
            };
            return directoryItem;
        }

        public static DirectoryStructure ToDirectoryStructure(List<string> directories)
        {
            List<DirectoryItem> directoryItems = new List<DirectoryItem>();
            foreach (var dir in directories)
            {
                directoryItems.Add(ToDirectoryItem(dir));
            }
            DirectoryStructure directoryStructure = new DirectoryStructure()
            {
                DirectoryItems = directoryItems
            };
            return directoryStructure;
        }
    }

}
