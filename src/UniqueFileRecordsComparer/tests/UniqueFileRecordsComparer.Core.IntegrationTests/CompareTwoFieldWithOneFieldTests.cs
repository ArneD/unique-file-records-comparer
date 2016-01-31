using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using Xunit;


namespace UniqueFileRecordsComparer.Core.IntegrationTests
{
    public class CompareTwoFieldWithOneFieldTests
    {
        private const string CsvFileWithHeadersPath = "TestFiles\\TwoFieldsCsvWithHeaders.csv";
        private const string ExcelFileWithHeadersPath = "TestFiles\\OneFieldXlsxWithHeaders.xlsx";

        [Fact]
        public void Test()
        {
            CheckFilesExist();

            var csvRows = new CsvReader(CsvFileWithHeadersPath, ";").Read(true).ToList();
            csvRows.Should().NotBeEmpty();

            var excelRows = new ExcelReader(ExcelFileWithHeadersPath).Read(true).ToList();
            excelRows.Should().NotBeEmpty();

            var compareTwoFields = new List<string> { "First name", "Last name" };
            var compareOneField = new List<string> { "Name" };

            var csvRowCollection = new RowCollection(csvRows, compareTwoFields);
            var excelRowCollection = new RowCollection(excelRows, compareOneField);

            var rowComparer = new RowComparer(csvRowCollection, excelRowCollection);
            var result = rowComparer.GetCollectionComparisonResult();

            result.NewRows.ShouldAllBeEquivalentTo(new List<Row>
            {
                new Row
                {
                    new Column("Nr", "2"),
                    new Column("Name", "New name"),
                    new Column("Address", "Test street 123")
                }
            });

            result.DeletedRows.ShouldAllBeEquivalentTo(new List<Row>
            {
                new Row
                {
                    new Column("ID", "12"),
                    new Column("First name", "Deleted"),
                    new Column("Last name", "Name"),
                    new Column("Address", "Hell 109")
                }
            });
        }

        private static void CheckFilesExist()
        {
            Assert.True(File.Exists(CsvFileWithHeadersPath));
            Assert.True(File.Exists(ExcelFileWithHeadersPath));
        }
    }

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

    public class RowCollectionComparisonResult
    {
        public IEnumerable<Row> NewRows { get; set; }
        public IEnumerable<Row> DeletedRows { get; set; }
        public IEnumerable<Row> EqualRows { get; set; }
    }
}
