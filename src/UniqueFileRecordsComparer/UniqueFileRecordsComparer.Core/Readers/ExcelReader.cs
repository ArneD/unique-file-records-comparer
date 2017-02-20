using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using Excel;

namespace UniqueFileRecordsComparer.Core.Readers
{
    public class ExcelReader : IFileReader
    {
        private readonly FileInfoBase _fileInfo;

        public ExcelReader(FileInfoBase fileInfo)
        {
            _fileInfo = fileInfo;
        }

        public RowCollection Read()
        {
            return new RowCollection(ExtractDataSet().ToList());
        }

        private IEnumerable<Row> ExtractDataSet()
        {
            using (var excelReader = ExcelReaderFactory.CreateOpenXmlReader(_fileInfo.Open(FileMode.Open, FileAccess.Read)))
            {
                excelReader.IsFirstRowAsColumnNames = true;
                using (var result = excelReader.AsDataSet())
                {
                    return GetRows(result);
                }
            }
        }

        private static IEnumerable<Row> GetRows(DataSet result)
        {
            var dataTable = result.Tables[0];

            return dataTable
                    .Rows
                    .Cast<DataRow>()
                    .Select(GetRow);
        }

        private static Row GetRow(DataRow dataRow)
        {
            var row = new Row();
            var i = 0;
            foreach (var item in dataRow.ItemArray)
            {
                row.Add(new Column(dataRow.Table.Columns[i].ColumnName, item.ToString().Trim()));
                i++;
            }
            return row;
        }
    }
}
