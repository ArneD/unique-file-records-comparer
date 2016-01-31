using System.Collections.Generic;

namespace UniqueFileRecordsComparer.Core
{
    public class ColumnValues
    {
        public ColumnValues(string header, IEnumerable<string> values)
        {
            Header = header;
            Values = values;
        }

        public string Header { get; }
        public IEnumerable<string> Values { get; set; }
    }
}
