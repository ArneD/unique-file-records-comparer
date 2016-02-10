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

        private IEnumerable<Row> GetNewRows(IEnumerable<Row> equalRows)
        {
            return _targetRowCollection.Except(equalRows);
        }

        private void FillEqualAndDeletedRows(ICollection<Row> equalRows, ICollection<Row> deletedRows)
        {
            foreach (var sourceRow in GetRowsOrderedByMaxLengthOfComparedColumns(_sourceRowCollection))
            {
                var targetRow = GetRowsOrderedByMaxLengthOfComparedColumns(_targetRowCollection)
                    .Except(equalRows)
                    .FirstOrDefault(row => sourceRow
                        .IsEqualTo(_sourceRowCollection.ColumnHeadersToCompare, row,
                            _targetRowCollection.ColumnHeadersToCompare));

                if (targetRow != null)
                {
                    equalRows.Add(targetRow);
                }
                else
                {
                    deletedRows.Add(sourceRow);
                }
            }
        }

        private IOrderedEnumerable<Row> GetRowsOrderedByMaxLengthOfComparedColumns(RowCollection collection)
        {
            return
                collection.OrderByDescending(
                    row => row.GetValueCombinations(collection.ColumnHeadersToCompare).Max(value => value.Length));
        }
    }
}