using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace UniqueFileRecordsComparer.Core.Tests
{
    public class When_constructing_ColumnValues
    {
        [Fact]
        public void Then_expected_values_are_set()
        {
            var expectedheader = "expectedHeader";
            var expectedValues = new List<string> {"abc", "foo"};

            var columnValues = new ColumnValues(expectedheader, expectedValues);

            columnValues.Header.Should().Be(expectedheader);\
            columnValues.Values.Should().BeEquivalentTo(expectedValues);
        }
    }
}
