using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace UniqueFileRecordsComparer.Core.IntegrationTests.CsvReaderTests
{
    public class When_reading_csv_file
    {
        private const string CsvFilePath = "TestFiles\\TwoFieldsCsvWithHeaders.csv";

        [Fact]
        public void Then_returns_the_expected_result()
        {
            var expectedResult = new Dictionary<string, IList<string>>
            {
                {
                    "ID", new List<string>
                    {
                        "2",
                        "3",
                        "9",
                        "10",
                        "12"
                    }
                },
                {
                     "First name", new List<string>
                     {
                         "Foo",
                         "First",
                         "John",
                         "John",
                         "Deleted"
                     }
                },
                {
                     "Last name", new List<string>
                     {
                         "Bar",
                         "Last",
                         "Smith",
                         "Doe",
                         "Name"
                     }
                },
                {
                     "Address", new List<string>
                     {
                         "Main street 1",
                         "Other street 2",
                         "Second street 96",
                         "Happy road 32",
                         "Hell 109"
                     }
                }
            };

            var result = new CsvReader(CsvFilePath, ";").Read(true);

            result.ShouldAllBeEquivalentTo(expectedResult);
        }
    }
}
