using System.IO.Abstractions;
using CsvHelper;

namespace UniqueFileRecordsComparer.Core.Writers
{
    public interface ICsvWriterFactory
    {
        ICsvWriter Create(FileInfoBase fileInfo);
    }
}