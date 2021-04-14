using System.Windows;
using System.IO;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Linq;
using System.Net;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Collections.Generic;

namespace RawJpegRemover
{
    public partial class MainWindow : Window
    {
        private DirectoryInfo jpgDir, rawDir;
        private int totalDeleted;
        private const int CharsToJumpOver = 2;
        private const int ExtensionLength = 4; // With dot
        private const int MinimalNeededLength = 6;
        private enum TypeSelect { JPG, RAW };

        private void InitializeRawSelector()
        {
            string[] rawFileExtensions;
            try
            {
                using (WebClient client = new WebClient())
                {
                    int index;
                    List<string> fileExtensions = new List<string>();
                    string [] delimiters = { "<tbody>" };
                    string htmlCode = client.DownloadString("https://fileinfo.com/filetypes/camera_raw");
                    string [] htmlCodeSplitted = htmlCode.Split(delimiters, System.StringSplitOptions.None);
                    string [] splittedLines = htmlCodeSplitted[1].Split('\n');
                    foreach (string splittedLine in splittedLines)
                    {
                        index = splittedLine.IndexOf("\">.");
                        if (index > 0 && splittedLine.Length > index + MinimalNeededLength)
                        {
                            // Adding charsToJumpOver to index since I got the index of the " and I want to jump over ">.
                            fileExtensions.Add(splittedLine.Substring(index + CharsToJumpOver, ExtensionLength));
                        }
                    }
                    fileExtensions.Sort();
                    rawFileExtensions = fileExtensions.ToArray();
                }
            }
            catch (WebException e)
            {
                // List taken from: https://fileinfo.com/filetypes/camera_raw 
                rawFileExtensions = new string[]{".3FR", ".ARI", ".ARW", ".BAY", ".CR2", ".CR3", ".CRW", ".CS1",
                                    ".CXI", ".DCR", ".DNG", ".EIP", ".ERF", ".FFF", ".IIQ", ".J6I",
                                    ".K25", ".KDC", ".MEF", ".MFW", ".MOS", ".MRW", ".NEF", ".NRW",
                                    ".ORF", ".PEF", ".RAF", ".RAW", ".RW2", ".RWL", ".RWZ", ".SR2",
                                    ".SRF", ".SRW", ".X3F"};
                System.Console.WriteLine(e.ToString()); // For debugging only.
            }
            foreach (string rawOption in rawFileExtensions)
            {
                rawTypeSelector.Items.Add(rawOption);
            }
        }
        public MainWindow()
        { 
            InitializeComponent();
            InitializeRawSelector();
        }
                
        private void GetFolderSelect(TextBlock textBlock, TypeSelect select)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (select == TypeSelect.JPG)
            {
                folderBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            }
            else if (jpgDir != null && select == TypeSelect.RAW)
            {
                // Folder browser will start from the same directory that the user set for Jpg files
                folderBrowser.SelectedPath = jpgDir.FullName;
            }
            if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (select == TypeSelect.JPG)
                {
                    jpgDir = new DirectoryInfo(folderBrowser.SelectedPath);
                    textBlock.Text = "The selected folder is: " + jpgDir.FullName;
                }
                // Using else if instead if, if I'll need to add another file type
                else if (select == TypeSelect.RAW)
                {
                    rawDir = new DirectoryInfo(folderBrowser.SelectedPath);
                    textBlock.Text = "The selected folder is: " + rawDir.FullName;
                }
            }
            else
            {
                MessageBox.Show("Problem occured during folder selection, please try again.");
            }
        }

        private void JpgFolderSelectButton_Click(object sender, RoutedEventArgs e)
        {
            GetFolderSelect(jpgFolderSelectText, TypeSelect.JPG);
        }

        private void RawFolderSelectButton_Click(object sender, RoutedEventArgs e)
        {
            GetFolderSelect(rawFolderSelectText, TypeSelect.RAW);
        }

        private bool CheckUserSelects()
        {
            // Check all the conditions to start the deletion - the user need to select folders and raw file type
            bool retVal = true;
            if (jpgDir == null)
            {
                MessageBox.Show("JPG folder not selected.");
                retVal = false;
            }
            if (rawDir == null)
            {
                MessageBox.Show("RAW folder not selected.");
                retVal = false;
            }
            if (rawTypeSelector.Text.Equals(""))
            {
                MessageBox.Show("Raw file type not selected.");
                retVal = false;
            }
            return retVal;
        }

        private bool JpgFileExists(FileInfo[] jpgFiles, string jpgFileNameVar1, string jpgFileNameVar2)
        {
            foreach (FileInfo jpgFile in jpgFiles)
            {
                if (jpgFile.Name.Equals(jpgFileNameVar1) || jpgFile.Name.Equals(jpgFileNameVar2))
                {
                    return true;
                }
            }
            return false;
        }

        private bool RawFileExists(FileInfo[] rawFiles, string rawFileNameVar)
        {
            foreach (FileInfo rawFile in rawFiles)
            {
                if (rawFile.Name.Equals(rawFileNameVar))
                {
                    return true;
                }
            }
            return false;
        }

        private void DeleteRawFilesByJpgFiles (string rawFileType)
        {
            FileInfo[] jpgFiles = jpgDir.EnumerateFiles()
                .Where(x => ".jpg".Contains(x.Extension.ToLower()))
                .ToArray();
            FileInfo[] rawFiles = rawDir.EnumerateFiles()
                .Where(x => rawFileType.Contains(x.Extension))
                .ToArray();
            if (jpgFiles.Length > 0)
            { 
                // I won't iterate over Raw files array if there are no Jpg files.
                foreach (FileInfo rawFile in rawFiles)
                {
                    string rawFileName = rawFile.Name;
                    int dotPos = rawFileName.LastIndexOf(".");
                    string noExtensionFileName = rawFileName.Substring(0, dotPos);
                    string jpgFileNameVar1 = noExtensionFileName + ".jpg",
                        jpgFileNameVar2 = noExtensionFileName + ".JPG";
                    if (JpgFileExists(jpgFiles, jpgFileNameVar1, jpgFileNameVar2))
                    {
                        continue;
                    }
                    else
                    {
                        rawFile.Delete();
                        totalDeleted++;
                    }
                }
            }
        }

        private void DeleteJpgFilesByRawFiles(string rawFileType)
        {
            FileInfo[] jpgFiles = jpgDir.EnumerateFiles()
                .Where(x => ".jpg".Contains(x.Extension.ToLower()))
                .ToArray();
            FileInfo[] rawFiles = rawDir.EnumerateFiles()
                .Where(x => rawFileType.Contains(x.Extension))
                .ToArray();
            if (rawFiles.Length > 0)
            { 
                // I won't iterate over Jpg files array if there are no Raw files.
                foreach (FileInfo jpgFile in jpgFiles)
                {
                    string JPGFileName = jpgFile.Name;
                    int dotPos = JPGFileName.LastIndexOf(".");
                    string noExtensionFileName = JPGFileName.Substring(0, dotPos);
                    string rawFileNameVar = noExtensionFileName + rawFileType;
                    if (RawFileExists(rawFiles, rawFileNameVar))
                    {
                        continue;
                    }
                    else
                    {
                        jpgFile.Delete();
                        totalDeleted++;
                    }
                }
            }
        }

        private void StartOperation_Click(object sender, RoutedEventArgs e)
        {
            if (CheckUserSelects())
            {
                startOperation.IsEnabled = false;
                string originalText = startOperation.Content.ToString();
                startOperation.Content = "Please wait, deleting files...";
                string rawFileType = rawTypeSelector.Text;
                totalDeleted = 0;
                if (rawByJpg.IsChecked.Value)
                {
                    DeleteRawFilesByJpgFiles(rawFileType);
                }
                else if (jpgByRaw.IsChecked.Value)
                {
                    DeleteJpgFilesByRawFiles(rawFileType);
                }
                else if (bothDelete.IsChecked.Value) // Both of them checked
                {
                    DeleteRawFilesByJpgFiles(rawFileType);
                    DeleteJpgFilesByRawFiles(rawFileType);
                }
                MessageBox.Show(string.Format("Operation completed, totally {0} files deleted.", totalDeleted));
                startOperation.Content = originalText;
                startOperation.IsEnabled = true;
            }
        }
    }
}