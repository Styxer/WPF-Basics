using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace WPF_Basics
{
    /// <summary>
    /// Interaction logic for TreeView.xaml
    /// </summary>
    public partial class TreeView : Window
    {

        #region Contructor
        /// <summary>
        /// defualt Contructor
        /// </summary>
        public TreeView()
        {
            InitializeComponent();
        }
        #endregion


        #region On Loaded
        /// <summary>
        /// get called when the windows loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //get every logical drive on the machine
            foreach (var drive in Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem()
                {
                    //header and the full path
                    Header = drive,
                    Tag = drive
                };
                
                //dummy item so we can expand folder
                item.Items.Add(null);

                item.Expanded += Folder_Expanded;

                FolderView.Items.Add(item);
            }
        }

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            #region Initial Checks

            var item = (TreeViewItem)sender;

            // If the item only contains the dummy data
            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            // Clear dummy data
            item.Items.Clear();

            
            var fullPath = (string)item.Tag;

            #endregion

            #region Get Folders
          
            var directories = new List<string>();

           
            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    directories.AddRange(dirs);
            }
            catch { }

            
            directories.ForEach(directoryPath =>
            {
                // Create directory item
                var subItem = new TreeViewItem()
                {
                   
                    Header = GetFileFolderName(directoryPath),                    
                    Tag = directoryPath
                };

                subItem.Items.Add(null);

                
                subItem.Expanded += Folder_Expanded;
              
                item.Items.Add(subItem);
            });

            #endregion

            #region Get Files

            
            var files = new List<string>();

          
            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    files.AddRange(fs);
            }
            catch { }

            
            files.ForEach(filePath =>
            {
                // Create file item
                var subItem = new TreeViewItem()
                {
                     Header = GetFileFolderName(filePath),                 
                    Tag = filePath
                };

              
                item.Items.Add(subItem);
            });

            #endregion
        }
        #endregion

        #region Helpers
        /// <summary>
        /// find the file or folder name from a full path
        /// </summary>
        /// <param name="path">the full path</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            //C:\Something\a folder
            //C:\Something \a file.***
            //a file.***

            if (String.IsNullOrEmpty(path))
                return String.Empty;

            var normalizedPath = path.Replace('/', '\\');

            var lastIndex = normalizedPath.LastIndexOf('\\');
            if (lastIndex <= 0)
                return path;

            return path.Substring(lastIndex + 1);


        } 
        #endregion
    }
}
