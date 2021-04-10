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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WordpadWPF.Helpers;
using TextBox = System.Windows.Controls.TextBox;

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
            if (String.IsNullOrWhiteSpace(_fileHelper.FileName))
            {
                SaveFile();
            }
            else
            {
                _fileHelper.AutoSave(TextBoxInput.Text);
            }
        }

        private void SaveFile()
        {
            _fileHelper.SaveDataToFile(TextBoxInput.Text);
            TextBlockFilePath.Text = _fileHelper.FileName;
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

        private void ButtonSaveAs_OnClick(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private void ButtonSelectFont_OnClick(object sender, RoutedEventArgs e)
        {
            var font = new FontDialog();

            if (font.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;

            TextBoxInput.FontFamily = new FontFamily(font.Font.Name);
            TextBoxInput.FontSize = font.Font.Size;
            TextBoxInput.FontWeight = font.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
            TextBoxInput.FontStyle = font.Font.Italic ? FontStyles.Italic:FontStyles.Normal;

            TextDecorationCollection tdc = new TextDecorationCollection();
            if (font.Font.Underline) tdc.Add(TextDecorations.Underline);
            if (font.Font.Strikeout) tdc.Add(TextDecorations.Strikethrough);
            TextBoxInput.TextDecorations = tdc;
        }

        private void ButtonSelectColor_OnClick(object sender, RoutedEventArgs e)
        {
            var color = new ColorDialog();

            if (color.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;

            TextBoxInput.Foreground = new SolidColorBrush(Color.FromArgb((byte)color.Color.A,
                                                                        (byte)color.Color.R, 
                                                                        (byte)color.Color.G,
                                                                        (byte)color.Color.B));

        }
    }
}