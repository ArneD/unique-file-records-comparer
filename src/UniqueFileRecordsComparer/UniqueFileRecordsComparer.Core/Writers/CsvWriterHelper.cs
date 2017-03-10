using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;

namespace UniqueFileRecordsComparer.Core.Writers
{
    public static class CsvWriterHelper
    {
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
