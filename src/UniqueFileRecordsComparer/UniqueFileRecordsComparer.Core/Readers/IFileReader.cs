using System.Collections.Generic;

namespace UniqueFileRecordsComparer.Core.Readers
{
    public interface IFileReader
    {
        RowCollection Read(int? tabIndex);
        IDictionary<int, string> GetTabNamesByIndex();
    }
}