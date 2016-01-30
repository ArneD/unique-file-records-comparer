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

        public IDictionary<string, IList<string>> Read(bool hasHeaders)
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

        private static IDictionary<string, IList<string>> ExtractDataSet(IExcelDataReader excelReader)
        {
            var rows = new Dictionary<string, IList<string>>();
            using (var result = excelReader.AsDataSet())
            {
                GetHeaders(result, rows);
                GetValues(result, rows);
            }
            return rows;
        }

        private static void GetValues(DataSet result, Dictionary<string, IList<string>> rows)
        {
            foreach (DataRow row in result.Tables[0].Rows)
            {
                int i = 0;
                foreach (var key in rows.Keys)
                {
                    rows[key].Add(row[i].ToString());
                    i++;
                }
            }
        }

        private static void GetHeaders(DataSet result, Dictionary<string, IList<string>> rows)
        {
            foreach (var column in result.Tables[0].Columns)
            {
                rows.Add(column.ToString(), new List<string>());
            }
        }
    }
}
