using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Directories;

namespace ViewModel.DirectoriesViewModel
{
    class DirectoryTreeViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        private DirectoryItem _currentItem;
        private DirectoryStructure _currentTree;
        public DirectoryItem CurrentItem
        {
            get { return this._currentItem; }
            set
            {
                if (this._currentItem == value)
                    return;
                
                    this._currentItem = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurrentItem)));
            }
        }

        public DirectoryStructure CurrentTree
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
    }
}
