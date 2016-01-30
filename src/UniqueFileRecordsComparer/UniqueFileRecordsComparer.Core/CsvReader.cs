using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper.Configuration;

namespace UniqueFileRecordsComparer.Core
{
    public class CsvReader
    {
        private readonly string _path;
        private CsvConfiguration _csvConfiguration;

        public CsvReader(string path)
        {
            _path = path;
        }

        public Dictionary<string, IList<string>> Read()
        {
            _csvConfiguration = new CsvConfiguration
            {
                HasHeaderRecord = true,
                Delimiter = ";",
            };

            Dictionary<string, IList<string>> dictionary;
            using (var csv = new CsvHelper.CsvReader(new StreamReader(_path), _csvConfiguration))
            {
                csv.Read();
                dictionary = csv.FieldHeaders.ToDictionary<string, string, IList<string>>(fieldHeader => fieldHeader, fieldHeader => new List<string>());

                do
                {
                    for (var i = 0; i < dictionary.Count; i++)
                    {
                        dictionary.ElementAt(i).Value.Add(csv.GetField(i));
                    }
                } while (csv.Read());
            }

            return dictionary;
        }
    }
}
