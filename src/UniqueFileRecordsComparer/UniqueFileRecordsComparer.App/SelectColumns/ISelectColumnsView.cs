using System.Collections.Generic;

namespace UniqueFileRecordsComparer.App.SelectColumns
{
    public interface ISelectColumnsView
    {
        IEnumerable<string> SourceColumns { get; set; }
        IEnumerable<string> TargetColumns { get; set; }

        IEnumerable<string> SourceCheckedColumns { get; }
        IEnumerable<string> TargetCheckedColumns { get; }

        SelectColumnsPresenter Presenter { set; }

        void Show();
    }
}