using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace UniqueFileRecordsComparer.Core.Tests.RowTests
{
    public class When_comparing_Rows
    {
        [Fact]
        public void Given_accents_in_name_Then_same_to_name_without_accents()
        {
            var compareColumns = new List<string>
            {
                "Name"
            };

            var row = new Row
            {
                new Column("Name", "Hélène")
            };

            var sameRow = new Row
            {
                new Column("Name", "Helene")
            };

            row.IsEqualTo(compareColumns, sameRow, compareColumns).Should().BeTrue();
        }

        [Fact]
        public void Given_capitals_in_name_Then_same_to_name_without_capitals()
        {
            var compareColumns = new List<string>
            {
                "Name"
            };

            var row = new Row
            {
                new Column("Name", "HélèNE")
            };

            var sameRow = new Row
            {
                new Column("Name", "helene")
            };

            row.IsEqualTo(compareColumns, sameRow, compareColumns).Should().BeTrue();
        }

        [Fact]
        public void Given_capitals_in_name_Then_same_to_name_with_other_capitals()
        {
            var compareColumns = new List<string>
            {
                "Name"
            };

            var row = new Row
            {
                new Column("Name", "HélèNE")
            };

            var sameRow = new Row
            {
                new Column("Name", "hELEne")
            };

            row.IsEqualTo(compareColumns, sameRow, compareColumns).Should().BeTrue();
        }

        [Fact]
        public void Given_quote_in_name_Then_same_to_name_without_quote_but_with_space()
        {
            var compareColumns = new List<string>
            {
                "Name"
            };

            var row = new Row
            {
                new Column("Name", "D'Test")
            };

            var sameRow = new Row
            {
                new Column("Name", "D Test")
            };

            row.IsEqualTo(compareColumns, sameRow, compareColumns).Should().BeTrue();
        }
    }
}
