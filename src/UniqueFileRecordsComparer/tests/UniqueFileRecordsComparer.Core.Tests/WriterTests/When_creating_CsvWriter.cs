using System.Collections.Generic;
using System.IO.Abstractions.TestingHelpers;
using CsvHelper;
using FluentAssertions;
using Xunit;

namespace UniqueFileRecordsComparer.Core.Tests.WriterTests
{
    public class When_creating_CsvWriter
    {
        [Fact]
        public void Then_CsvWriter_is_created()
        {
            var mockFileDatas = new Dictionary<string, MockFileData>();
            var fileFactory = new MockFileInfoFactory(new MockFileSystem(mockFileDatas));

            var writer = new Writers.CsvWriterFactory().Create(fileFactory.FromFileName("test.csv"));

            writer.Should().NotBeNull();
            writer.Should().BeOfType<CsvWriter>();
        }
    }
}
