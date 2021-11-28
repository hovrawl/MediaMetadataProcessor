using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using TagLib;
using File = TagLib.File;

namespace MediaMetadataProcessor
{
    public partial class MainForm : Form
    {

        private string _selectedPath = "";

        private List<TagLib.File> _selectedFiles = new List<File>();

        public MainForm()
        {
            InitializeComponent();
        }

        public void Initialize()
        {

            lblDirectory.Visible = false;
        }


        private void SelectDirectory()
        {
            // Open Folder picker dialog -- Old CommonOpenFileDialog as it is better for selecting items
            using (var fbd = new CommonOpenFileDialog { IsFolderPicker = true })
            {
                var result = fbd.ShowDialog();
                if (result == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    _selectedPath = fbd.FileName;
                    // update list view with files from new path
                    UpdateListView();
                    lblDirectory.Visible = true;
                    lblDirectory.Text = _selectedPath;
                }
              
            }
        }

        private void UpdateListView()
        {
            if (string.IsNullOrEmpty(_selectedPath))
            {
                return;
            }

            var directory = new DirectoryInfo(_selectedPath);
            var files = directory.EnumerateFiles();
            var tFiles = new List<TagLib.File>();
            var gridTags = new List<Tag>();
            var tagNames = new List<string>();
            // Get TagLib Files from files
            foreach (var file in files)
            {
                try
                {
                    var tFile = TagLib.File.Create(file.FullName);

                    // Take out tags
                    var tag = tFile.Tag;
                    if (tag.IsEmpty)
                    {
                        continue;
                    }
                    tFiles.Add(tFile);
                    gridTags.Add(tFile.Tag);
                   // TODO - Determine file type to get hard coded list of columns as string, then set column names on grid after enumeration
                }
                catch
                {
                    /*unsupported file*/
                }
            }

            _selectedFiles = tFiles;
            gridFiles.DataSource = gridTags;
        }

        private void ProcessFiles()
        {
             // open dialog to select which metadata fields to process
             var processDialog = new ProcessForm(_selectedFiles);
             var result = processDialog.ShowDialog();
             if (processDialog._processed)
             {
                 MessageBox.Show("Processed", "Metadata", MessageBoxButtons.OK,MessageBoxIcon.Information);
                 UpdateListView();
             }
        }


        private void btnSelDirectory_Click(object sender, EventArgs e)
        {
            SelectDirectory();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            ProcessFiles();
        }
    }
}
