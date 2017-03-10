using System.Collections.Generic;
using System.IO.Abstractions;
using FluentAssertions;
using Moq;
using UniqueFileRecordsComparer.App.SelectColumns;
using UniqueFileRecordsComparer.Core;
using UniqueFileRecordsComparer.Core.Readers;
using Xunit;

namespace UniqueFileRecordsComparer.App.Tests.SelectColumns
{
    public class When_comparing_files
    {
        private readonly Mock<IRowCollectionComparer> _rowCollectionComparerMock;
        private readonly Mock<ISelectColumnsView> _viewMock;
        private readonly SelectColumnsPresenter _presenter;

        public When_comparing_files()
        {
            var sourceFileReaderMock = new Mock<IFileReader>();
            var sourceRows = new List<Row>
            {
                new Row { new Column("A", "1"), new Column("B", "2") }
            };
            sourceFileReaderMock.Setup(reader => reader.Read(0)).Returns(new RowCollection(sourceRows));

            var fileReaderFactoryMock = new Mock<IFileReaderFactory>();
            fileReaderFactoryMock
                .Setup(factory => factory.CreateFromFileName(It.IsAny<FileInfoBase>()))
                .Returns(sourceFileReaderMock.Object);

            _viewMock = new Mock<ISelectColumnsView>();
            _viewMock.SetupGet(view => view.SourceCheckedColumns).Returns(new List<string>());
            _viewMock.SetupGet(view => view.TargetCheckedColumns).Returns(new List<string>());

            _rowCollectionComparerMock = new Mock<IRowCollectionComparer>();
            _presenter = new SelectColumnsPresenter(_viewMock.Object, fileReaderFactoryMock.Object,
                _rowCollectionComparerMock.Object);

            _presenter.Load(new ComparerArguments
            {
                SourceFilePath = "test",
                TargetFilePath = "test"
            });
        }

        [Fact]
        public void Then_columns_are_called_from_the_view()
        {
            _presenter.CompareFiles();
            _viewMock.VerifyGet(view => view.SourceCheckedColumns);
            _viewMock.VerifyGet(view => view.TargetCheckedColumns);
        }

        [Fact]
        public void Then_task_is_returned_and_RowCollectionComparer_GetCollectionComparisonResult_is_called()
        {
            var task = _presenter.CompareFiles();
            task.Should().NotBeNull();

            task.Wait();

            _rowCollectionComparerMock.Verify(comparer => comparer.GetCollectionComparisonResult(It.IsAny<RowCollection>(), It.IsAny<RowCollection>()));
        }
    }
}

