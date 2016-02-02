using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace UniqueFileRecordsComparer.Core.Tests.RowTests
{
    public class When_getting_ColumnHeaders
    {
        [Fact]
        public void Then_returns_expected_Headers()
        {
            var rowCollection = new RowCollection(new List<Row>
            {
                new Row
                {
                    new Column("Test", "Test"),
                    new Column("Foo", "Bar"),
                    new Column("Abc", "Def")
                }
            });

            var expectedHeaders = new List<string> { "Test", "Foo", "Abc" };

            rowCollection.GetColumnHeaders().ShouldAllBeEquivalentTo(expectedHeaders);
        }

        [Fact]
        public void Given_empty_collection_Then_returns_empty_Headers_list()
        {
            var rowCollection = new RowCollection(new List<Row>());

            rowCollection.GetColumnHeaders().Should().BeEmpty();
        }
    }
}
