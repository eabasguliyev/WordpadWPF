using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordpadWPF.Helpers
{
    class FileHelper
    {
        public string FileName { get; set; }
        public string ReadDataFromFile()
        {
            var open = new OpenFileDialog();
            open.Filter = "Txt Files (*.txt)| *.txt";

            if (open.ShowDialog() != true)
                return String.Empty;

            FileName = open.FileName;

            return File.ReadAllText(FileName);
        }

        public void SaveDataToFile(string data)
        {
            var save = new SaveFileDialog();

            save.Filter = "Txt Files (*.txt)| *.txt";

            if (save.ShowDialog() != true)
                return;

            FileName = GetAbsolouteFilePath(save.FileName);

            File.WriteAllText(FileName, data);
        }

        public void AutoSave(string data)
        {
            if (String.IsNullOrWhiteSpace(FileName))
                return;

            File.WriteAllText(FileName, data);
        }
        private string GetAbsolouteFilePath(string filePath)
        {
            return filePath.EndsWith(".txt") ? filePath : filePath + ".txt";
        }
    }
}
