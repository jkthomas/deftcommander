using Helpers.Commands;
using Helpers.SystemDirectories;
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

        public ICommand CreateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand MoveCommand { get; set; }
        public ICommand CopyCommand { get; set; }
        #endregion

        public CommanderViewModel()
        {
            this.FirstDirectoryViewModel = new DirectoryListViewModel()
            {
                IsFocused = true
            };
            this.SecondDirectoryViewModel = new DirectoryListViewModel();

            this.SwitchFocusCommand = new RelayCommand(this.SwitchFocus);
            this.CreateCommand = new RelayCommand(this.Create);
            this.DeleteCommand = new RelayCommand(this.Delete);
            this.MoveCommand = new RelayCommand(this.Move);
            this.CopyCommand = new RelayCommand(this.Copy);
        }

        public DirectoryListViewModel FirstDirectoryViewModel { get; set; }
        public DirectoryListViewModel SecondDirectoryViewModel { get; set; }

        //TODO: Implement all methods with command parameter
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
        public void Create()
        {
            if (FirstDirectoryViewModel.IsFocused)
            {
                WindowsDirectoryOperationsService.CreateDirectory(
                    WindowsDirectoryAcquireService.GetParent(this.FirstDirectoryViewModel.CurrentPath), "TESTFOLDER");
            }
            if (SecondDirectoryViewModel.IsFocused)
            {
                WindowsDirectoryOperationsService.CreateDirectory(
                    WindowsDirectoryAcquireService.GetParent(this.SecondDirectoryViewModel.CurrentPath), "TESTFOLDER");
            }
        }
        public void Delete()
        {
            if (FirstDirectoryViewModel.IsFocused)
            {
                WindowsDirectoryOperationsService.DeleteDirectory(this.FirstDirectoryViewModel.CurrentPath);
            }
            if (SecondDirectoryViewModel.IsFocused)
            {
                WindowsDirectoryOperationsService.DeleteDirectory(this.SecondDirectoryViewModel.CurrentPath);
            }
        }
        public void Move()
        {
            if (FirstDirectoryViewModel.IsFocused)
            {
                WindowsDirectoryOperationsService.MoveDirectory(this.FirstDirectoryViewModel.CurrentPath, this.SecondDirectoryViewModel.CurrentPath);
            }
            if (SecondDirectoryViewModel.IsFocused)
            {
                WindowsDirectoryOperationsService.MoveDirectory(this.SecondDirectoryViewModel.CurrentPath, this.FirstDirectoryViewModel.CurrentPath);
            }
        }
        public void Copy()
        {
            if (FirstDirectoryViewModel.IsFocused)
            {
                WindowsDirectoryOperationsService.CopyDirectory(this.FirstDirectoryViewModel.CurrentPath, this.SecondDirectoryViewModel.CurrentPath);
            }
            if (SecondDirectoryViewModel.IsFocused)
            {
                WindowsDirectoryOperationsService.CopyDirectory(this.SecondDirectoryViewModel.CurrentPath, this.FirstDirectoryViewModel.CurrentPath);
            }
        }
        #endregion
    }
}
