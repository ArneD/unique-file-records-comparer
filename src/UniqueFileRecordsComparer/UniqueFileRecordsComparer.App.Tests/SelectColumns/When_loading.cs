using System.Collections.Generic;
using System.IO.Abstractions;
using Moq;
using UniqueFileRecordsComparer.App.SelectColumns;
using UniqueFileRecordsComparer.Core;
using UniqueFileRecordsComparer.Core.Readers;
using Xunit;

namespace UniqueFileRecordsComparer.App.Tests.SelectColumns
{
    public class When_loading
    {
        private readonly Mock<ISelectColumnsView> _viewMock;

        public When_loading()
        {
            var sourceFileReaderMock = new Mock<IFileReader>();
            var sourceRows = new List<Row>
            {
                new Row { new Column("A", "1"), new Column("B", "2") }
            };
            sourceFileReaderMock.Setup(reader => reader.Read(0)).Returns(new RowCollection(sourceRows));

            var targetFileReaderMock = new Mock<IFileReader>();
            var targetRows = new List<Row>
            {
                new Row { new Column("AB", "1 2") }
            };
            targetFileReaderMock.Setup(reader => reader.Read(0)).Returns(new RowCollection(targetRows));

            var fileReaderFactoryMock = new Mock<IFileReaderFactory>();
            fileReaderFactoryMock
                .Setup(factory => factory.CreateFromFileName(It.Is<FileInfoWrapper>(f => f.Name == "Test.csv")))
                .Returns(sourceFileReaderMock.Object);

            fileReaderFactoryMock
                .Setup(factory => factory.CreateFromFileName(It.Is<FileInfoWrapper>(f => f.Name == "Test.xlsx")))
                .Returns(targetFileReaderMock.Object);

            _viewMock = new Mock<ISelectColumnsView>();
            var presenter = new SelectColumnsPresenter(_viewMock.Object, fileReaderFactoryMock.Object, Mock.Of<IRowCollectionComparer>());

            var comparerArguments = new ComparerArguments
            {
                SourceFilePath = "Test.csv",
                SourceFileTabIndex = 0,
                TargetFilePath = "Test.xlsx",
                TargetFileTabIndex = 0
            };

            presenter.Load(comparerArguments);
        }

        [Fact]
        public void Then_SourceColumns_are_set_as_expected()
        {
            _viewMock.VerifySet(view => view.SourceColumns = new List<string> { "A", "B"});
            
        }

        [Fact]
        public void Then_TagetColumns_are_set_as_expected()
        {
            _viewMock.VerifySet(view => view.TargetColumns = new List<string> { "AB" });
        }

        [Fact]
        public void Then_Show_is_called()
        {
            _viewMock.Verify(view => view.Show());
        }
    }
}
