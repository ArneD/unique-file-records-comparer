using System.Collections.Generic;
using UniqueFileRecordsComparer.App.SelectFiles;

namespace UniqueFileRecordsComparer.App.Tests.SelectFiles
{
    public class SelectFileViewStub : ISelectFilesView
    {
        public string SourceFilePath { get; set; }
        public string TargetFilePath { get; set; }
        public IList<string> SourceFileTabs { get; set; }
        public IList<string> TargetFileTabs { get; set; }
        public int SelectedSourceFileTabIndex { get; set; }
        public int SelectedTargetFileTabIndex { get; set; }
        public SelectFilesPresenter Presenter { get; set; }
    }
}