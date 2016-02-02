using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace UniqueFileRecordsComparer.Core.Readers
{
    public class CsvReader : IFileReader
    {
        private readonly string _path;
        private readonly CsvConfiguration _csvConfiguration;

        public CsvReader(string path, string delimiter)
        {
            _path = path;

            _csvConfiguration = new CsvConfiguration
            {
                Delimiter = delimiter
            };
        }

        public RowCollection Read(bool hasHeaders)
        {
            _csvConfiguration.HasHeaderRecord = hasHeaders;

            IList<Row> rows;
            using (var csv = new CsvHelper.CsvReader(new StreamReader(_path), _csvConfiguration))
            {
                rows = ReadCsv(csv).ToList();
            }

            return new RowCollection(rows);
        }

        private static IEnumerable<Row> ReadCsv(ICsvReader csv)
        {
            var rows = new List<Row>();
            while (csv.Read())
            {
                var row = new Row();
                for (var i = 0; i < csv.CurrentRecord.Length; i++)
                {
                    row.Add(new Column(csv.FieldHeaders[i], csv.CurrentRecord[i].Trim()));
                }
                rows.Add(row);
            }

            return rows;
        }
    }
}
