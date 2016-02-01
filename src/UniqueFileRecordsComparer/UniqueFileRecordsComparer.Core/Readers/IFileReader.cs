using System.Collections.Generic;

namespace UniqueFileRecordsComparer.Core.Readers
{
    public interface IFileReader
    {
        IEnumerable<Row> Read(bool hasHeaders);
    }
}