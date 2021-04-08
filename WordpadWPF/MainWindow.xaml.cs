using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WordpadWPF.Helpers;

namespace WordpadWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileHelper _fileHelper;
        public MainWindow()
        {
            _fileHelper = new FileHelper();

            InitializeComponent();
        }

        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            TextBoxInput.Text = _fileHelper.ReadDataFromFile();
            TextBlockFilePath.Text = _fileHelper.FileName;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            _fileHelper.SaveDataToFile(TextBoxInput.Text);
        }

        private void TextBoxInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(sender is TextBox textBox))
                return;

            if (ToggleButtonAutoSave.IsChecked != true)
                return;

            _fileHelper.AutoSave(textBox.Text);
        }

        private void ButtonCut_Click(object sender, RoutedEventArgs e)
        {
            TextBoxInput.Cut();
        }

        private void ButtonCopy_Click(object sender, RoutedEventArgs e)
        {
            TextBoxInput.Copy();
            TextBoxInput.Focus();
        }

        private void ButtonPaste_Click(object sender, RoutedEventArgs e)
        {
            TextBoxInput.Paste();
        }

        private void ButtonSelectAll_Click(object sender, RoutedEventArgs e)
        {
            TextBoxInput.Focus();
            TextBoxInput.SelectAll();
        }
    }
}