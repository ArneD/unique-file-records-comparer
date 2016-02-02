using System;
using FluentAssertions;
using UniqueFileRecordsComparer.Core.Readers;
using Xunit;

namespace UniqueFileRecordsComparer.Core.Tests.ReaderTests
{
    public class When_creating_a_FileReader
    {
        [Fact]
        public void Given_FileName_ends_with_dot_csv_Then_returns_CsvReader()
        {
            var reader = FileReaderFactory.CreateFromFileName("test.csv");
            reader.Should().BeOfType<CsvReader>();
        }

        [Fact]
        public void Given_FileName_ends_with_dot_xlsx_Then_returns_ExcelReader()
        {
            var reader = FileReaderFactory.CreateFromFileName("test.xlsx");
            reader.Should().BeOfType<ExcelReader>();
        }

        [Fact]
        public void Given_FileName_ends_with_invalid_extension_Then_returns_InvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => FileReaderFactory.CreateFromFileName("test.txt"));
        }
    }
}
