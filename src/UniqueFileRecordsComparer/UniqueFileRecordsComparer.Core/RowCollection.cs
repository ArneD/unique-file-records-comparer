using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace UniqueFileRecordsComparer.Core
{
    public class RowCollection : Collection<Row>
    {
        public RowCollection(IList<Row> rows, IList<string> columnHeadersToCompare)
            : base(rows)
        {
            ColumnHeadersToCompare = columnHeadersToCompare;
        }

        public IList<string> ColumnHeadersToCompare { get; }
        public IEnumerable<ColumnValues> ColumnsToCompare
        {
            get
            {
                var headers = Items.First().Select(column => column.Header);
                var dictionary = headers.ToDictionary(header => header, s => new List<string>());

                foreach (var column in Items.SelectMany(row => row))
                {
                    dictionary[column.Header].Add(column.Value);
                }

                return dictionary
                    .Where(kvp => ColumnHeadersToCompare.Any(header => header == kvp.Key))
                    .Select(kvp => new ColumnValues(kvp.Key, kvp.Value));
            }
        }
    }
}
