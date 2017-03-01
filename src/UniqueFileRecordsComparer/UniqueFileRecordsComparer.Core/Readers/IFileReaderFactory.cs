using System.IO.Abstractions;

namespace UniqueFileRecordsComparer.Core.Readers
{
    public interface IFileReaderFactory
    {
        IFileReader CreateFromFileName(FileInfoBase fileInfoBase);
    }
}