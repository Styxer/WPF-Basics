using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WPF_Basics
{
    /// <summary>
    /// Converts a full path to a specific image type of a drive, folder or file
    /// </summary>
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public  class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //var path = value?.ToString();


            //var name = DirectoryStructure.GetFileFolderName(path);//String.IsNullOrEmpty(Path.GetFileNameWithoutExtension(path)) ? Path.GetDirectoryName(path) : Path.GetFileNameWithoutExtension(path);

            //var image = String.Empty;

            //// If the name is blank, we presume it's a drive as we cannot have a blank file or folder name
            
            //if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
            //    image = "Images/folder-closed.png";
            //else
            //{                
                
            //    if (ImageExtensions.Contains(Path.GetExtension(path).ToUpperInvariant()))
            //        image = "Images/Image.png";
            //    else
            //        image = "Images/file.png"; 
                
            //}



            //  return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
            return new BitmapImage(new Uri($"pack://application:,,,/Images/{value}.png"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
