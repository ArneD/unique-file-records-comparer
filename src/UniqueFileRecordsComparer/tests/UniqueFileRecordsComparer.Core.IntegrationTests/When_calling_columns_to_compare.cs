using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace UniqueFileRecordsComparer.Core.IntegrationTests
{
    public class When_calling_columns_to_compare
    {
        private readonly RowCollection _rowCollection;
        public When_calling_columns_to_compare()
        {
            var dictionary = new List<Row>
            {
                new Row
                {
                    new Column("Test", "a"),
                    new Column("Ignore", "value"),
                    new Column("Second", "d")
                },
                new Row
                {
                    new Column("Test", "b"),
                    new Column("Ignore", "test"),
                    new Column("Second", "e")
                }
            };

            _rowCollection = new RowCollection(dictionary, new List<string> {"Test", "Second"});
        }

        [Fact]
        public void Then_returns_only_records_to_compare_to()
        {
            var expectedRows = new List<ColumnValues>
            {
                new ColumnValues("Test", new List<string> {"a", "b"}),
                new ColumnValues("Second", new List<string> {"d", "e"})
            };

            _rowCollection.ColumnsToCompare.ShouldAllBeEquivalentTo(expectedRows);
        }
    }
}
