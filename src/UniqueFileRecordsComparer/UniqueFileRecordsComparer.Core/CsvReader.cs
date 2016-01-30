using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace UniqueFileRecordsComparer.Core
{
    public class CsvReader
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

        public IDictionary<string, IList<string>> Read(bool hasHeaders)
        {
            _csvConfiguration.HasHeaderRecord = hasHeaders;

            Dictionary<string, IList<string>> dictionary;
            using (var csv = new CsvHelper.CsvReader(new StreamReader(_path), _csvConfiguration))
            {
                dictionary = ReadCsv(csv);
            }

            return dictionary;
        }

        private static Dictionary<string, IList<string>> ReadCsv(ICsvReader csv)
        {
            csv.Read();
            var dictionary = csv.FieldHeaders.ToDictionary<string, string, IList<string>>(fieldHeader => fieldHeader,
                fieldHeader => new List<string>());

            do
            {
                for (var i = 0; i < dictionary.Count; i++)
                {
                    dictionary.ElementAt(i).Value.Add(csv.GetField(i));
                }
            } while (csv.Read());

            return dictionary;
        }
    }
}
