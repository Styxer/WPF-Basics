using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Basics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show( $"The Description is  { DescriptionTxtBox.Text }" );
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            WeldCheckBox.IsChecked = AssemblyCheckBox.IsChecked = PlasmaCheckBox.IsChecked = LaserCheckBox.IsChecked = PurchaseCheckBox.IsChecked =
                LaserCheckBox.IsChecked = DrillCheckBox.IsChecked = FoldCheckBox.IsChecked = RollCheckBox.IsChecked = SawCheckBox.IsChecked = false;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
            LenghtCheckBox.Text += ((CheckBox)sender).Content + " ";
            
               

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var checkBoxTxt = ((CheckBox)sender).Content.ToString();
            LenghtCheckBox.Text = LenghtCheckBox.Text.Replace(checkBoxTxt, String.Empty); 
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NoteTextBox != null)
            {
                var comboBox = (ComboBox)sender;
                var value = ((ComboBoxItem)comboBox.SelectedValue).Content.ToString();

                NoteTextBox.Text = value;
            }
        



        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox_SelectionChanged(FinishComboBox, null);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MassTextBox.Text = SupplierNameTextBox.Text;
            
        }

        private void GoToTreeViewBtn_Click(object sender, RoutedEventArgs e)
        {
            TreeView treeViewWindows = new TreeView();
            treeViewWindows.ShowDialog();
        }
    }
}
