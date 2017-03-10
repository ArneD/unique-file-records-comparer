using System.Collections.Generic;
using UniqueFileRecordsComparer.Core;

namespace UniqueFileRecordsComparer.App.ComparisonResults
{
    public interface IComparisonResultsView
    {
        IList<Row> NewRows { get; set; }
        IList<Row> DeletedRows { get; set; }

        ComparisonResultsPresenter Presenter { set; }
        void Show();
    }
}