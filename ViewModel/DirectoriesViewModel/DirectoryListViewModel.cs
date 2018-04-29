using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers.SystemDirectories;

namespace ViewModel.DirectoriesViewModel
{
    public class DirectoryListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public DirectoryListViewModel()
        {
            this.CurrentPath = null;
            this.CurrentTree = new ObservableCollection<string>(WindowsDirectoryAcquireService.GetComputerDrives());
        }

        #region Current path and tree fields
        private string _currentPath;
        private ObservableCollection<string> _currentTree;
        public string CurrentPath
        {
            get { return this._currentPath; }
            set
            {
                if (this._currentPath == value)
                    return;

                this._currentPath = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurrentPath)));
            }
        }

        public ObservableCollection<string> CurrentTree
        {
            get { return this._currentTree; }
            set
            {
                if (this._currentTree == value)
                    return;

                this._currentTree = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurrentTree)));
            }
        }
        #endregion


    }
}