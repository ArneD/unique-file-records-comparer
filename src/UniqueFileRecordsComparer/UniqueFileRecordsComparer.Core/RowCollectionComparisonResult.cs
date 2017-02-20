using System.Collections.Generic;

namespace UniqueFileRecordsComparer.Core
{
    public class RowCollectionComparisonResult
    {
        public RowCollectionComparisonResult(IEnumerable<Row> newRows, IEnumerable<Row> deletedRows, IEnumerable<Row> equalRows)
        {
            NewRows = newRows;
            DeletedRows = deletedRows;
            EqualRows = equalRows;
        }

        public IEnumerable<Row> NewRows { get; set; }
        public IEnumerable<Row> DeletedRows { get; set; }
        public IEnumerable<Row> EqualRows { get; set; }
    }
}