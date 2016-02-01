using System.Collections.Generic;
using System.Linq;

namespace UniqueFileRecordsComparer.Core
{
    public class RowComparer
    {
        private readonly RowCollection _sourceRowCollection;
        private readonly RowCollection _targetRowCollection;

        public RowComparer(RowCollection sourceRowCollection, RowCollection targetRowCollection)
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
                bool targetFound = false;
                foreach (var targetRow in _targetRowCollection)
                {
                    var targetCombinations = targetRow.GetValueCombinations(_targetRowCollection.ColumnHeadersToCompare);
                    if (sourceRow.GetValueCombinations(_sourceRowCollection.ColumnHeadersToCompare)
                        .Any(x => targetCombinations.Any(y => x.ToUpperInvariant().Contains(y.ToUpperInvariant())))
                        || targetCombinations.Any(target => HasTargetStringAllSourceValues(target, sourceRow)))
                    {
                        equalRows.Add(targetRow);
                        targetFound = true;
                        break;
                    }
                }

                if (!targetFound)
                {
                    deletedRows.Add(sourceRow);
                }
            }
        }

        private bool HasTargetStringAllSourceValues(string target, Row sourceRow)
        {
            var allValues = _sourceRowCollection.ColumnHeadersToCompare.Select(sourceRow.GetColumnValueByHeader).ToList();

            return allValues.All(value => target.ToUpperInvariant().Contains(value.ToUpperInvariant()));
        }
    }
}