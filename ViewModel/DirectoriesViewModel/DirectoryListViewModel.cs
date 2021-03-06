﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Helpers.Commands;
using Helpers.SystemDirectories;

namespace ViewModel.DirectoriesViewModel
{
    public class DirectoryListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #region Commands
        public ICommand ChangeCurrentTreeCommand { get; set; }
        public ICommand ReturnToParentTreeCommand { get; set; }
        #endregion

        #region Fields
        private string _currentPath;
        private ObservableCollection<string> _currentTree;
        private bool _isFocused;
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
        
        public bool IsFocused
        {
            get { return this._isFocused; }
            set
            {
                if (this._isFocused == value)
                    return;

                this._isFocused = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsFocused)));
            }
        }
        #endregion

        public DirectoryListViewModel()
        {
            this.CurrentTree = new ObservableCollection<string>(WindowsDirectoryAcquireService.GetComputerDrives());
            this.CurrentPath = CurrentTree.First().ToString();
            this.ChangeCurrentTreeCommand = new RelayCommand(this.ChangeCurrentTree);
            this.ReturnToParentTreeCommand = new RelayCommand(this.ReturnToParentTree);
        }

        public void ChangeCurrentTree()
        {
            try
            {
                this.CurrentTree = new ObservableCollection<string>(WindowsDirectoryAcquireService.GetDiretoryTree(CurrentPath));
                this.CurrentPath = CurrentTree.First().ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("An empty directory or general failure: " + e.Message);
            }
        }

        public void ReturnToParentTree()
        {
            try
            {
                this.CurrentTree = new ObservableCollection<string>(WindowsDirectoryAcquireService.GetDirectoryParentTree(CurrentPath));
                this.CurrentPath = CurrentTree.First().ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("An empty directory or general failure: " + e.Message);
            }
        }
    }
}