﻿using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Excel;

namespace UniqueFileRecordsComparer.Core.Readers
{
    public class ExcelReader : IFileReader
    {
        private readonly string _path;

        public ExcelReader(string path)
        {
            _path = path;
        }

        public RowCollection Read(bool hasHeaders)
        {
            using (var stream = File.Open(_path, FileMode.Open, FileAccess.Read))
            {
                using (var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                {
                    excelReader.IsFirstRowAsColumnNames = hasHeaders;
                    return new RowCollection(ExtractDataSet(excelReader).ToList());
                }
            }
        }

        private static IEnumerable<Row> ExtractDataSet(IExcelDataReader excelReader)
        {
            using (var result = excelReader.AsDataSet())
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
    }
}
