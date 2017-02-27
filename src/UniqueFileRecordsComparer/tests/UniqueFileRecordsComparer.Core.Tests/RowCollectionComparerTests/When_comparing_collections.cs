using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace UniqueFileRecordsComparer.Core.Tests.RowCollectionComparerTests
{
    public class When_comparing_collections
    {
        [Fact]
        public void Given_source_and_target_collection_has_one_name_that_the_second_name_contains_Then_both_are_added_to_equal_rows()
        {
            var compareColumn = new List<string> {"Name"};
            var rows = new List<Row>
            {
                new Row
                {
                    new Column("Name", "Foo Bar")
                },
                new Row
                {
                    new Column("Name", "Foo Barr")
                }
            };

            var sourceCollection = new RowCollection(rows) {ColumnHeadersToCompare = compareColumn};
            var targetCollection = new RowCollection(rows) {ColumnHeadersToCompare = compareColumn};

            var comparisonResult = new RowCollectionComparer(sourceCollection, targetCollection).GetCollectionComparisonResult();

            comparisonResult.EqualRows.ShouldAllBeEquivalentTo(rows);
        }
    }
}
