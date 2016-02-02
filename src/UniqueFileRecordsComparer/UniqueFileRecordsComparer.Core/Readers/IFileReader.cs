namespace UniqueFileRecordsComparer.Core.Readers
{
    public interface IFileReader
    {
        RowCollection Read(bool hasHeaders);
    }
}