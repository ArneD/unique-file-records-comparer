using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Excel;

namespace UniqueFileRecordsComparer.Core.Readers
{
    public class ExcelReader : IFileReader
    {
        private readonly IExcelDataReader _excelDataReader;

        public ExcelReader(IExcelDataReader excelDataReader)
        {
            _excelDataReader = excelDataReader;
        }

        public RowCollection Read()
        {
            return new RowCollection(ExtractDataSet().ToList());
        }

        private IEnumerable<Row> ExtractDataSet()
        {
            using (var result = _excelDataReader.AsDataSet())
            {
                return GetRows(result);
            }
        }

        private static IEnumerable<Row> GetRows(DataSet result)
        {
            var rows = new List<Row>();
            var dataTable = result.Tables[0];

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var row = new Row();
                var i = 0;
                foreach (var item in dataRow.ItemArray)
                {
                    row.Add(new Column(dataTable.Columns[i].ColumnName, item.ToString().Trim()));
                    i++;
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
                _excelDataReader?.Dispose();
            }
        }
    }
}
