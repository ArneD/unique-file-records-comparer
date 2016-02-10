using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;

namespace UniqueFileRecordsComparer.Core.Readers
{
    public class CsvReader : IFileReader
    {
        private readonly ICsvReader _reader;

        public CsvReader(ICsvReader reader)
        {
            _reader = reader;
        }

        public RowCollection Read()
        {
            IList<Row> rows = ReadCsv().ToList();
            return new RowCollection(rows);
        }

        private IEnumerable<Row> ReadCsv()
        {
            var rows = new List<Row>();
            while (_reader.Read())
            {
                var row = new Row();
                for (var i = 0; i < _reader.CurrentRecord.Length; i++)
                {
                    row.Add(new Column(_reader.FieldHeaders[i], _reader.CurrentRecord[i].Trim()));
                }
                rows.Add(row);
            }

            return rows;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _reader?.Dispose();
            }
        }
    }
}
