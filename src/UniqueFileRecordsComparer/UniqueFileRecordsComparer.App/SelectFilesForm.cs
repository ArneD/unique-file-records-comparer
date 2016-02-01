using System;
using System.Windows.Forms;

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
        }

        private void ChooseTargetFileButton_Click(object sender, EventArgs e)
        {
            _comparerArguments.TargetFilePath = GetFilePathFromDialog();
            TargetFilePathLabel.Text = _comparerArguments.TargetFilePath;
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
