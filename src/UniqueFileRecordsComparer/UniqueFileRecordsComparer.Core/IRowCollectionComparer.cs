namespace UniqueFileRecordsComparer.Core
{
    public interface IRowCollectionComparer
    {
        RowCollectionComparisonResult GetCollectionComparisonResult(RowCollection sourceRowCollection, RowCollection targetRowCollection);
    }
}