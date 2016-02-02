using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace UniqueFileRecordsComparer.Core
{
    public class RowCollection : Collection<Row>
    {
        public RowCollection(IList<Row> rows)
            : base(rows)
        { }

        public IList<string> ColumnHeadersToCompare { get; set; }

        public IEnumerable<string> GetColumnHeaders()
        {
            return Items.Any()
                ? Items.First().Select(column => column.Header)
                : new List<string>();
        }
    }
}
