using System.IO;
using System.IO.Abstractions;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace UniqueFileRecordsComparer.Core.Writers
{
    public class CsvWriterFactory : ICsvWriterFactory
    {
        public ICsvWriter Create(FileInfoBase fileInfo)
        {
            var csvConfiguration = new CsvConfiguration
            {
                Delimiter = ";",
                HasHeaderRecord = true
            };

            var streamWriter = new StreamWriter(fileInfo.OpenWrite(), Encoding.UTF8);
            return new CsvHelper.CsvWriter(streamWriter, csvConfiguration);
        }
    }
}