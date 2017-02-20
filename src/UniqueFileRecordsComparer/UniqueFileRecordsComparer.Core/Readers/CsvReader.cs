using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace UniqueFileRecordsComparer.Core.Readers
{
    public class CsvReader : IFileReader
    {
        private readonly FileInfoBase _fileInfo;

        public CsvReader(FileInfoBase fileInfo)
        {
            _fileInfo = fileInfo;
        }

        public RowCollection Read()
        {
            IList<Row> rows = ReadCsv().ToList();
            return new RowCollection(rows);
        }

        private IEnumerable<Row> ReadCsv()
        {
            using (var reader = CreateCsvReader())
            {
                var rows = new List<Row>();
                while (reader.Read())
                {
                    rows.Add(GetRow(reader));
                }

                return rows;
            }
        }

        private static Row GetRow(ICsvReader csvReader)
        {
            var row = new Row();
            for (var i = 0; i < csvReader.CurrentRecord.Length; i++)
            {
                row.Add(new Column(csvReader.FieldHeaders[i], csvReader.CurrentRecord[i].Trim()));
            }
            return row;
        }

        private CsvHelper.CsvReader CreateCsvReader()
        {
            return new CsvHelper.CsvReader(new StreamReader(_fileInfo.OpenRead()), new CsvConfiguration
            {
                HasHeaderRecord = true,
                Delimiter = ";"
            });
        }
    }
}
