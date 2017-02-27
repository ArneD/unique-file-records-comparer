using System;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Windows.Forms;
using UniqueFileRecordsComparer.Core.Readers;

namespace UniqueFileRecordsComparer.App
{
    public partial class SelectFilesForm : Form
    {
        private readonly ComparerArguments _comparerArguments;

        public SelectFilesForm()
        {
            InitializeComponent();
            _comparerArguments = new ComparerArguments();
        }

        private void ChooseSourceFileButton_Click(object sender, EventArgs e)
        {
            _comparerArguments.SourceFilePath = GetFilePathFromDialog();
            SourceFilePathLabel.Text = _comparerArguments.SourceFilePath;

            FillTabs(SourceFileTabsDropDown, _comparerArguments.SourceFilePath);
        }

        private void ChooseTargetFileButton_Click(object sender, EventArgs e)
        {
            _comparerArguments.TargetFilePath = GetFilePathFromDialog();
            TargetFilePathLabel.Text = _comparerArguments.TargetFilePath;

            FillTabs(TargetFileTabsDropDown, _comparerArguments.TargetFilePath);
        }

        private void FillTabs(ComboBox fileTabsDropDown, string path)
        {
            fileTabsDropDown.Items.Clear();
            fileTabsDropDown.Enabled = false;

            var fileReader = FileReaderFactory.CreateFromFileName(new FileInfoWrapper(new FileInfo(path)));
            if (fileReader.GetTabNamesByIndex().Keys.Count > 1)
            {
                foreach (var tab in fileReader.GetTabNamesByIndex())
                {
                    fileTabsDropDown.Items.Insert(tab.Key, tab.Value);
                }
                fileTabsDropDown.Enabled = true;
                fileTabsDropDown.SelectedIndex = 0;
            }
        }

        private static string GetFilePathFromDialog()
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.CheckFileExists = true;
                dialog.Title = "Choose file";
                dialog.Filter = @"Data file |*.csv;*.xlsx";

                var result = dialog.ShowDialog();

                if(result == DialogResult.OK)
                    return dialog.FileName;
            }
            return "";
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (IsFormValid())
            {
                _comparerArguments.SourceFileTabIndex = SourceFileTabsDropDown.SelectedIndex;
                _comparerArguments.TargetFileTabIndex = TargetFileTabsDropDown.SelectedIndex;

                var selectColumnsForm = new SelectColumnsForm(_comparerArguments);
                selectColumnsForm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Please select a source and a target file");
            }
        }

        private bool IsFormValid()
        {
            return !string.IsNullOrEmpty(_comparerArguments.SourceFilePath) &&
                   !string.IsNullOrEmpty(_comparerArguments.TargetFilePath);
        }
    }
}
