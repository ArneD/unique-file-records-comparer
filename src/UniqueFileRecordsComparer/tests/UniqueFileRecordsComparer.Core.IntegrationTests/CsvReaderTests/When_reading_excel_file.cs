using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace UniqueFileRecordsComparer.Core.IntegrationTests.CsvReaderTests
{
    public class When_reading_excel_file
    {
        const string ExcelFilePath = "TestFiles\\OneFieldXlsxWithHeaders.xlsx";

        [Fact]
        public void Then_returns_the_expected_result()
        {
            var expectedResult = new Dictionary<string, IList<string>>
            {
                {
                    "Nr", new List<string>
                    {
                        "2",
                        "4",
                        "5",
                        "6",
                        "7"
                    }
                },
                {
                     "Name", new List<string>
                     {
                         "New name",
                         "Bar Foo",
                         "First Middle Last",
                         "Smith J. John",
                         "Doe John Jr."
                     }
                },
                {
                     "Address", new List<string>
                     {
                         "Test street 123",
                         "Main street 1",
                         "Other street 2",
                         "Second street 98",
                         "Happy road 32"
                     }
                }
            };

            var result = new ExcelReader(ExcelFilePath).Read(true);

            result.ShouldAllBeEquivalentTo(expectedResult);
        }
    }
}
