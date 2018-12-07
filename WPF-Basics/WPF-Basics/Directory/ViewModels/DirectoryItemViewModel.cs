using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Basics
{
    /// <summary>
    /// view model for each dir item
    /// </summary>
    public class DirectoryItemViewModel : BaseViewModel
    {

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="fullPath">The full path of this item</param>
        /// <param name="type">The type of item</param>
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            // Create commands
           // ExpandCommand = new RelayCommand(Expand);

            // Set path and type
            this.FullPath = fullPath;
            this.Type = type;

            // Setup the children as needed
            this.ClearChildren();
        }

        #endregion

        #region Public Properties
        public string FullPath { get; set; }

        public string Name { get { return Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileFolderName(FullPath); } }

        public DirectoryItemType Type { get; set; }

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }

        public bool IsExpanded
        {
            get
            {
                return Children?.Count(f => f != null) > 0;
            }
            set
            {
                // If the UI tells us to expand...
                if (value == true)
                    // Find all children
                    Expand();
                // If the UI tells us to close
                else
                    ClearChildren();
            }
        }

        #endregion

        #region helper Functions
        private void ClearChildren()
        {
            // Clear items
            Children = new ObservableCollection<DirectoryItemViewModel>();

            // Show the expand arrow if we are not a file
            if (Type != DirectoryItemType.File)
                Children.Add(null);
        }


        private void Expand()
        {
            // We cannot expand a file
            if (Type == DirectoryItemType.File)
                return;

            // Find all children
            var children = DirectoryStructure.GetDirectoryContents(FullPath);
            Children = new ObservableCollection<DirectoryItemViewModel>(
                                children.Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        } 
        #endregion
    }
}

