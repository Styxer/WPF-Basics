using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Basics
{
    /// <summary>
    /// info about a dir item such a drive, file or a folder
    /// </summary>
    public class DirectoryItem
    {
        
        public DirectoryItemType Type { get; set; }

       
        public string FullPath { get; set; }

     
        public string Name { get { return Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileFolderName(FullPath); } }
    }
}
