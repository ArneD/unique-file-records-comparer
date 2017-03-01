using System.Collections.Generic;

namespace UniqueFileRecordsComparer.App.SelectFiles
{
    public interface ISelectFilesView
    {
        string SourceFilePath { get; set; }
        string TargetFilePath { get; set; }

        IList<string> SourceFileTabs { get; set; }
        IList<string> TargetFileTabs { get; set; }

        int SelectedSourceFileTabIndex { get; set; }
        int SelectedTargetFileTabIndex { get; set; }

        SelectFilesPresenter Presenter { set; }
    }
}
