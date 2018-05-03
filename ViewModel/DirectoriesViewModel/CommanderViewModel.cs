using Helpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.DirectoriesViewModel
{
    public class CommanderViewModel
    {
        #region Commands
        public ICommand SwitchFocusCommand { get; set; }
        #endregion

        public CommanderViewModel()
        {
            this.FirstDirectoryViewModel = new DirectoryListViewModel()
            {
                IsFocused = true
            };

            this.SecondDirectoryViewModel = new DirectoryListViewModel();
            this.SwitchFocusCommand = new RelayCommand(this.SwitchFocus);
        }

        public DirectoryListViewModel FirstDirectoryViewModel { get; set; }
        public DirectoryListViewModel SecondDirectoryViewModel { get; set; }

        #region Methods
        public void SwitchFocus()
        {
            if (FirstDirectoryViewModel.IsFocused)
            {
                FirstDirectoryViewModel.IsFocused = false;
                SecondDirectoryViewModel.IsFocused = true;
            }
            else
            {
                SecondDirectoryViewModel.IsFocused = false;
                FirstDirectoryViewModel.IsFocused = true;
            }
        }

        #endregion
    }
}
