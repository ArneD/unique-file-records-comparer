using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using FluentAssertions;
using UniqueFileRecordsComparer.Core.Readers;
using Xunit;

namespace UniqueFileRecordsComparer.Core.IntegrationTests
{
    public class When_getting_tab_names_by_index
    {
        private const string XlsxWithMultipeTabsPath = "TestFiles\\FileWithMultipleTabs.xlsx";
        private const string CsvFilePath = "TestFiles\\TwoFieldsCsvWithHeaders.csv";

        [Fact]
        public void Given_excel_file_Then_expected_names_are_returned()
        {
            var expectedDictionary = new Dictionary<int, string>
            {
                { 0, "Data" },
                { 1, "Small Set" },
                { 2, "Tab3" }
            };

            var reader = FileReaderFactory.CreateFromFileName(new FileInfoWrapper(new FileInfo(XlsxWithMultipeTabsPath)));

            reader.GetTabNamesByIndex().ShouldAllBeEquivalentTo(expectedDictionary);
        }

        [Fact]
        public void Given_csv_file_Then_empty_dictionary_is_expected()
        {
            var reader = FileReaderFactory.CreateFromFileName(new FileInfoWrapper(new FileInfo(CsvFilePath)));

            reader.GetTabNamesByIndex().ShouldAllBeEquivalentTo(new Dictionary<int, string>());
        }
    }
}
