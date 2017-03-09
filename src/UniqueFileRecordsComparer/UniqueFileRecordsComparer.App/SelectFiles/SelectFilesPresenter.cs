using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using UniqueFileRecordsComparer.App.Messages;
using UniqueFileRecordsComparer.Core.Readers;

namespace UniqueFileRecordsComparer.App.SelectFiles
{
    public class SelectFilesPresenter
    {
        private readonly ISelectFilesView _view;
        private readonly IOpenFileMessageHandler _openFileMessageHandler;
        private readonly IFileReaderFactory _fileReaderFactory;

        public SelectFilesPresenter(ISelectFilesView view, IOpenFileMessageHandler openFileMessageHandler, IFileReaderFactory fileReaderFactory)
        {
            _view = view;
            _openFileMessageHandler = openFileMessageHandler;
            _fileReaderFactory = fileReaderFactory;
            view.Presenter = this;
        }

        public void SelectSourcePath()
        {
            var path = GetFilePathFromDialog();

            _view.SourceFilePath = path;
            _view.SourceFileTabs = GetTabs(path).Values.ToList();
        }

        public void SelectTargetPath()
        {
            var path = GetFilePathFromDialog();
            _view.TargetFilePath = path;
            _view.TargetFileTabs = GetTabs(path).Values.ToList();
        }

        public bool IsViewValid => !string.IsNullOrWhiteSpace(_view.SourceFilePath) &&
            !string.IsNullOrWhiteSpace(_view.TargetFilePath) && 
            _view.SelectedSourceFileTabIndex >= 0 &&
            _view.SelectedTargetFileTabIndex >= 0;

        private string GetFilePathFromDialog()
        {
            return _openFileMessageHandler.Handle(new OpenFileMessage
            {
                CheckFileExists = true,
                Title = "Choose file",
                Filter = @"Data file |*.csv;*.xlsx"
            });
        }

        private IDictionary<int, string> GetTabs(string path)
        {
            var fileReader = _fileReaderFactory.CreateFromFileName(new FileInfoWrapper(new FileInfo(path)));
            return fileReader.GetTabNamesByIndex();
        }
    }
}