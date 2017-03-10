using System.Collections.Generic;
using System.IO.Abstractions;
using System.Windows.Forms;
using CsvHelper;
using Moq;
using UniqueFileRecordsComparer.App.ComparisonResults;
using UniqueFileRecordsComparer.App.MessageHandlers;
using UniqueFileRecordsComparer.Core;
using UniqueFileRecordsComparer.Core.Writers;
using Xunit;

namespace UniqueFileRecordsComparer.App.Tests.ComparisonResults
{
    public class When_writing_rows
    {
        private readonly Mock<ICsvWriter> _csvWriterMock;
        private readonly Mock<ISaveFileMessageHandler> _saveFileDialogHandlerMock;
        private readonly string _expectedFileName = "test.csv";

        public When_writing_rows()
        {
            _saveFileDialogHandlerMock = new Mock<ISaveFileMessageHandler>();
            
            _saveFileDialogHandlerMock
                .Setup(handler => handler.Handle(It.IsAny<SaveFileDialog>()))
                .Callback<SaveFileDialog>(dialog => dialog.FileName = _expectedFileName)
                .Returns(DialogResult.OK);

            var csvWriterFactoryMock = new Mock<ICsvWriterFactory>();
            _csvWriterMock = new Mock<ICsvWriter>();

            csvWriterFactoryMock
                .Setup(writer => writer.Create(It.IsAny<FileInfoBase>()))
                .Returns(_csvWriterMock.Object);

            var presenter = new ComparisonResultsPresenter(Mock.Of<IComparisonResultsView>(), _saveFileDialogHandlerMock.Object, csvWriterFactoryMock.Object);

            var expectedRows = new List<Row>
            {
                new Row { new Column("foo", "123456"), new Column("bar", "ABCDEF") }
            };
            presenter.WriteRows(expectedRows);
        }

        [Fact]
        public void Then_SaveFileMessageHandler_is_called()
        {
            _saveFileDialogHandlerMock.Verify(handler => handler.Handle(It.IsAny<SaveFileDialog>()), Times.Once);
        }

        [Fact]
        public void Then_writer_is_called_to_write_expected_headers_and_values()
        {
            _csvWriterMock.Verify(writer => writer.WriteField("foo"), Times.Once);
            _csvWriterMock.Verify(writer => writer.WriteField("bar"), Times.Once);
            _csvWriterMock.Verify(writer => writer.WriteField("123456"), Times.Once);
            _csvWriterMock.Verify(writer => writer.WriteField("ABCDEF"), Times.Once);

            _csvWriterMock.Verify(writer => writer.NextRecord(), Times.Exactly(2));
        }
    }
}
