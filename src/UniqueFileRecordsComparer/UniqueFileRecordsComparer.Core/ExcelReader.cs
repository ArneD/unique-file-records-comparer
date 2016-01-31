using System.Collections.Generic;
using System.Data;
using System.IO;
using Excel;

namespace UniqueFileRecordsComparer.Core
{
    public class ExcelReader
    {
        private readonly string _path;

        public ExcelReader(string path)
        {
            _path = path;
        }

        public IEnumerable<Row> Read(bool hasHeaders)
        {
            using (var stream = File.Open(_path, FileMode.Open, FileAccess.Read))
            {
                using (var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                {
                    excelReader.IsFirstRowAsColumnNames = hasHeaders;
                    return ExtractDataSet(excelReader);
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
                    row.Add(new Column(dataTable.Columns[i].ColumnName, item.ToString()));
                    i++;
                }
                rows.Add(row);
            }

            return rows;
        }
    }
}
