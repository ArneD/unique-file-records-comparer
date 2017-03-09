using System.Collections.Generic;
using System.Linq;

namespace UniqueFileRecordsComparer.Core
{
    public class RowCollectionComparer : IRowCollectionComparer
    {
        private RowCollection _sourceRowCollection;
        private RowCollection _targetRowCollection;
        private List<Row> _equalRows;
        private List<Row> _deletedRows;

        public RowCollectionComparisonResult GetCollectionComparisonResult(RowCollection sourceRowCollection, RowCollection targetRowCollection)
        {
            _sourceRowCollection = sourceRowCollection;
            _targetRowCollection = targetRowCollection;

            _equalRows = new List<Row>();
            _deletedRows = new List<Row>();

            CompareSourceWithTargetRows();

            return new RowCollectionComparisonResult(GetNewRows(), _deletedRows, _equalRows);
        }

        private IEnumerable<Row> GetNewRows()
        {
            return _targetRowCollection.Except(_equalRows);
        }

        private void CompareSourceWithTargetRows()
        {
            var targetRowsOrderedByMaxLengthOfComparedColumns = GetRowsOrderedByMaxLengthOfComparedColumns(_targetRowCollection).ToList();

            foreach (var sourceRow in GetRowsOrderedByMaxLengthOfComparedColumns(_sourceRowCollection))
            {
                var targetRow = targetRowsOrderedByMaxLengthOfComparedColumns
                    .Except(_equalRows)
                    .FirstOrDefault(row => sourceRow
                        .IsEqualTo(_sourceRowCollection.ColumnHeadersToCompare, row,
                            _targetRowCollection.ColumnHeadersToCompare));

                FillEqualOrDeletedRows(targetRow, sourceRow);
            }
        }

        private void FillEqualOrDeletedRows(Row targetRow, Row sourceRow)
        {
            if (targetRow != null)
            {
                _equalRows.Add(targetRow);
            }
            else
            {
                _deletedRows.Add(sourceRow);
            }
        }

        private static IEnumerable<Row> GetRowsOrderedByMaxLengthOfComparedColumns(RowCollection collection)
        {
            return
                collection.OrderByDescending(
                    row => row.GetValueCombinations(collection.ColumnHeadersToCompare).Max(value => value.Length));
        }
    }
}