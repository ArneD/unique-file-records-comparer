using System;
using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using FluentAssertions;
using UniqueFileRecordsComparer.Core.Readers;
using Xunit;

namespace UniqueFileRecordsComparer.Core.Tests.ReaderTests
{
    public class When_creating_a_FileReader
    {
        private readonly MockFileInfoFactory _fileFactory;

        public When_creating_a_FileReader()
        {
            var mockFileDatas = new Dictionary<string, MockFileData>();
            mockFileDatas.Add("test.csv", new MockFileData("abc"));
            mockFileDatas.Add("test.xlsx", new MockFileData("abc"));

            _fileFactory = new MockFileInfoFactory(new MockFileSystem(mockFileDatas));
        }

        [Fact]
        public void Given_FileName_ends_with_dot_csv_Then_returns_CsvReader()
        {
            var reader = new FileReaderFactory().CreateFromFileName(_fileFactory.FromFileName("test.csv"));
            reader.Should().BeOfType<CsvReader>();
        }

        [Fact]
        public void Given_FileName_ends_with_dot_xlsx_Then_returns_ExcelReader()
        {
            var reader = new FileReaderFactory().CreateFromFileName(_fileFactory.FromFileName("test.xlsx"));
            reader.Should().BeOfType<ExcelReader>();
        }

        [Fact]
        public void Given_FileName_ends_with_invalid_extension_Then_returns_InvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => new FileReaderFactory().CreateFromFileName(_fileFactory.FromFileName("test.txt")));
        }
    }
}
