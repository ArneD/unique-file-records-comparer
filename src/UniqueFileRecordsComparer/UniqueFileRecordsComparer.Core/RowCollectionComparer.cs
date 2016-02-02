using System.Collections.Generic;
using System.Linq;

namespace UniqueFileRecordsComparer.Core
{
    public class RowCollectionComparer
    {
        private readonly RowCollection _sourceRowCollection;
        private readonly RowCollection _targetRowCollection;

        public RowCollectionComparer(RowCollection sourceRowCollection, RowCollection targetRowCollection)
        {
            _sourceRowCollection = sourceRowCollection;
            _targetRowCollection = targetRowCollection;
        }

        public RowCollectionComparisonResult GetCollectionComparisonResult()
        {
            var result = new RowCollectionComparisonResult();

            var equalRows = new List<Row>();
            var deletedRows = new List<Row>();

            FillEqualAndDeletedRows(equalRows, deletedRows);

            result.NewRows = GetNewRows(equalRows);
            result.DeletedRows = deletedRows;
            result.EqualRows = equalRows;

            return result;
        }

        private IEnumerable<Row> GetNewRows(ICollection<Row> equalRows)
        {
            return _targetRowCollection.Where(targetRow => !equalRows.Contains(targetRow)).ToList();
        }

        private void FillEqualAndDeletedRows(ICollection<Row> equalRows, ICollection<Row> deletedRows)
        {
            foreach (var sourceRow in _sourceRowCollection)
            {
                var targetFound = false;
                foreach (var targetRow in _targetRowCollection
                                .Where(targetRow => sourceRow
                                    .IsEqualTo(_sourceRowCollection.ColumnHeadersToCompare, targetRow, _targetRowCollection.ColumnHeadersToCompare)))
                {
                    equalRows.Add(targetRow);
                    targetFound = true;
                    break;
                }

                if (!targetFound)
                {
                    deletedRows.Add(sourceRow);
                }
            }
        }
    }
}