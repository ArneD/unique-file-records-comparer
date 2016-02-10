using System;

namespace UniqueFileRecordsComparer.Core.Readers
{
    public interface IFileReader : IDisposable
    {
        RowCollection Read();
    }
}