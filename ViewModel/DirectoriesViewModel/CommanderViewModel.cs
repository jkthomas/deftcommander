using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.DirectoriesViewModel
{
    public class CommanderViewModel
    {
        public CommanderViewModel()
        {
            this.FirstDirectoryViewModel = new DirectoryListViewModel();
            this.SecondDirectoryViewModel = new DirectoryListViewModel();
        }

        public DirectoryListViewModel FirstDirectoryViewModel { get; set; }
        public DirectoryListViewModel SecondDirectoryViewModel { get; set; }
    }
}
