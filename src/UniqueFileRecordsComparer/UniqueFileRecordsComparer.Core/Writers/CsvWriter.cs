using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace UniqueFileRecordsComparer.Core.Writers
{
    public static class CsvWriter
    {
        public static ICsvWriter Create(FileInfoBase fileInfo)
        {
            var csvConfiguration = new CsvConfiguration
            {
                Delimiter = ";",
                HasHeaderRecord = true
            };

            var streamWriter = new StreamWriter(fileInfo.OpenWrite(), Encoding.UTF8);
            return new CsvHelper.CsvWriter(streamWriter, csvConfiguration);
        }

        public static void WriteToCsv(ICsvWriter writer, IList<Row> rows)
        {
            if (!rows.Any())
                throw new InvalidOperationException("No rows to be written");

            WriteHeaders(rows, writer);

            foreach (var row in rows)
            {
                WriteRowValues(row, writer);
            }
        }

        private static void WriteHeaders(IEnumerable<Row> rows, ICsvWriter writer)
        {
            foreach (var column in rows.First())
            {
                writer.WriteField(column.Header);
            }
            writer.NextRecord();
        }

        private static void WriteRowValues(Row row, ICsvWriter writer)
        {
            foreach (var column in row)
            {
                writer.WriteField(column.Value);
            }
            writer.NextRecord();
        }
    }
}
