using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace UniqueFileRecordsComparer.Core.Tests
{
    public class When_constructing_RowCollectionComparisonResult
    {
        [Fact]
        public void Then_expected_values_are_set()
        {
            var newRows = new List<Row> { new Row { new Column("foo", "bar")} };
            var deletedRows = new List<Row> { new Row { new Column("tom", "jerry")} };
            var equalRows = new List<Row>
            {
                new Row { new Column("unique", "comparer"), new Column("test", "test")},
                new Row { new Column("bar", "foo")}
            };
            
            var rowCollectionComparisonResult = new RowCollectionComparisonResult(newRows, deletedRows, equalRows);

            rowCollectionComparisonResult.EqualRows.ShouldBeEquivalentTo(equalRows);
            rowCollectionComparisonResult.DeletedRows.ShouldBeEquivalentTo(deletedRows);
            rowCollectionComparisonResult.NewRows.ShouldBeEquivalentTo(newRows);
        }
    }
}
