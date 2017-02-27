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

        public RowCollection Read(int? tabIndex)
        {
            return new RowCollection(ExtractDataSet(tabIndex ?? 0).ToList());
        }

        public IDictionary<int, string> GetTabNamesByIndex()
        {
            var dictionary = new Dictionary<int, string>();
            int index = 0;
            using (var excelReader = ExcelReaderFactory.CreateOpenXmlReader(_fileInfo.OpenRead()))
            {
                foreach (DataTable table in excelReader.AsDataSet().Tables)
                {
                    dictionary.Add(index++, table.TableName);
                }
            }

            return dictionary;
        }

        private IEnumerable<Row> ExtractDataSet(int tabIndex)
        {
            using (var excelReader = ExcelReaderFactory.CreateOpenXmlReader(_fileInfo.Open(FileMode.Open, FileAccess.Read)))
            {
                excelReader.IsFirstRowAsColumnNames = true;
                using (var table = excelReader.AsDataSet().Tables[tabIndex])
                {
                    return GetRows(table);
                }
            }
        }

        private IEnumerable<Row> GetRows(DataTable table)
        {
            return table
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
