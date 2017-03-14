using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Windows.Forms;
using UniqueFileRecordsComparer.App.MessageHandlers;
using UniqueFileRecordsComparer.Core.Readers;

namespace UniqueFileRecordsComparer.App.SelectFiles
{
    public class SelectFilesPresenter
    {
        public ISelectFilesView View { get; set; }
        private readonly IOpenFileMessageHandler _openFileMessageHandler;
        private readonly IFileReaderFactory _fileReaderFactory;

        public SelectFilesPresenter(IOpenFileMessageHandler openFileMessageHandler, IFileReaderFactory fileReaderFactory)
        {
            _openFileMessageHandler = openFileMessageHandler;
            _fileReaderFactory = fileReaderFactory;
        }

        public void SelectSourcePath()
        {
            var path = GetFilePathFromDialog();

            View.SourceFilePath = path;
            View.SourceFileTabs = GetTabs(path).Values.ToList();
        }

        public void SelectTargetPath()
        {
            var path = GetFilePathFromDialog();
            View.TargetFilePath = path;
            View.TargetFileTabs = GetTabs(path).Values.ToList();
        }

        public bool IsViewValid => !string.IsNullOrWhiteSpace(View.SourceFilePath) &&
            !string.IsNullOrWhiteSpace(View.TargetFilePath) &&
            (View.SourceFileTabs.Count == 0 || (View.SourceFileTabs.Count > 0 && View.SelectedSourceFileTabIndex >= 0)) &&
            (View.TargetFileTabs.Count == 0 || (View.TargetFileTabs.Count > 0 && View.SelectedTargetFileTabIndex >= 0));

        public void Show()
        {
            View.Show();
        }

        private string GetFilePathFromDialog()
        {
            using (var openFileDialog = new OpenFileDialog
                {
                    CheckFileExists = true,
                    Title = "Choose file",
                    Filter = @"Data file |*.csv;*.xlsx"
                })
            {
                var result = _openFileMessageHandler.Handle(openFileDialog);

                return result == DialogResult.OK ? openFileDialog.FileName : string.Empty;
            }
        }

        private IDictionary<int, string> GetTabs(string path)
        {
            var fileReader = _fileReaderFactory.CreateFromFileName(new FileInfoWrapper(new FileInfo(path)));
            return fileReader.GetTabNamesByIndex();
        }
    }
}