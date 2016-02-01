using System.Collections.Generic;

namespace UniqueFileRecordsComparer.Core
{
    public class RowCollectionComparisonResult
    {
        public IEnumerable<Row> NewRows { get; set; }
        public IEnumerable<Row> DeletedRows { get; set; }
        public IEnumerable<Row> EqualRows { get; set; }
    }
}