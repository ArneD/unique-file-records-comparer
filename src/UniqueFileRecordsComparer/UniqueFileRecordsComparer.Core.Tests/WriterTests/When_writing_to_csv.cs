using System;
using System.Collections.Generic;
using CsvHelper;
using Moq;
using Xunit;
using CsvWriter = UniqueFileRecordsComparer.Core.Writers.CsvWriter;

namespace UniqueFileRecordsComparer.Core.Tests.WriterTests
{
    public class When_writing_to_csv
    {
        private readonly Mock<ICsvWriter> _csvWriter;
        private readonly Column _expectedColumn;

        public When_writing_to_csv()
        {
            _csvWriter = new Mock<ICsvWriter>();
            _expectedColumn = new Column("A", "B");

            CsvWriter.WriteToCsv(_csvWriter.Object, new List<Row> {new Row
            {
                _expectedColumn
            } });
        }

        [Fact]
        public void Then_the_expected_Column_Header_is_written()
        {
            _csvWriter.Verify(writer => writer.WriteField(_expectedColumn.Header));
        }

        [Fact]
        public void Then_the_expected_Column_Value_is_written()
        {
            _csvWriter.Verify(writer => writer.WriteField(_expectedColumn.Value));
        }

        [Fact]
        public void Given_no_rows_Then_returns_InvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => CsvWriter.WriteToCsv(_csvWriter.Object, new List<Row>()));
        }
    }
}
