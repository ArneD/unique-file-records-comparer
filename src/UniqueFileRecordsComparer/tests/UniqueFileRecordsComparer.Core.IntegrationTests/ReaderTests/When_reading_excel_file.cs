using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using FluentAssertions;
using UniqueFileRecordsComparer.Core.Readers;
using Xunit;

namespace UniqueFileRecordsComparer.Core.IntegrationTests.ReaderTests
{
    public class When_reading_excel_file
    {
        private const string ExcelFilePath = "TestFiles\\OneFieldXlsxWithHeaders.xlsx";

        [Fact]
        public void Then_returns_the_expected_result()
        {
            var expectedResult = new List<Row>
            {
                new Row
                {
                    new Column("Nr", "2"),
                    new Column("Name", "New name"),
                    new Column("Address", "Test street 123")
                },
                new Row
                {
                    new Column("Nr", "4"),
                    new Column("Name", "Bar Foo"),
                    new Column("Address", "Main street 1")
                },
                new Row
                {
                    new Column("Nr", "5"),
                    new Column("Name", "First Middle Last"),
                    new Column("Address", "Other street 2")
                },
                new Row
                {
                    new Column("Nr", "6"),
                    new Column("Name", "Smith J. John"),
                    new Column("Address", "Second street 98")
                },
                new Row
                {
                    new Column("Nr", "7"),
                    new Column("Name", "Doe John Jr."),
                    new Column("Address", "Happy road 32")
                },
                new Row
                {
                    new Column("Nr", "8"),
                    new Column("Name", "D'Family Name"),
                    new Column("Address", "ABC Road 1")
                }
            };

            var result = FileReaderFactory.CreateFromFileName(new FileInfoWrapper(new FileInfo(ExcelFilePath))).Read(0);

            result.ShouldAllBeEquivalentTo(expectedResult);
        }
    }
}
