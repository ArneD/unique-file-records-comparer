using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace UniqueFileRecordsComparer.Core.IntegrationTests.ReaderTests
{
    public class When_reading_csv_file
    {
        private const string CsvFilePath = "TestFiles\\TwoFieldsCsvWithHeaders.csv";

        [Fact]
        public void Then_returns_the_expected_result()
        {
            var expectedResult = new List<Row>
            {
                new Row
                {
                    new Column("ID", "2"),
                    new Column("First name", "Foo"),
                    new Column("Last name", "Bar"),
                    new Column("Address", "Main street 1")
                },
                new Row
                {
                    new Column("ID", "3"),
                    new Column("First name", "First"),
                    new Column("Last name", "Last"),
                    new Column("Address", "Other street 2")
                },
                new Row
                {
                    new Column("ID", "9"),
                    new Column("First name", "John"),
                    new Column("Last name", "Smith"),
                    new Column("Address", "Second street 96")
                },
                new Row
                {
                    new Column("ID", "10"),
                    new Column("First name", "John"),
                    new Column("Last name", "Doe"),
                    new Column("Address", "Happy road 32")
                },
                new Row
                {
                    new Column("ID", "12"),
                    new Column("First name", "Deleted"),
                    new Column("Last name", "Name"),
                    new Column("Address", "Hell 109")
                }
            };

            var result = new CsvReader(CsvFilePath, ";").Read(true);

            result.ShouldAllBeEquivalentTo(expectedResult);
        }
    }
}
