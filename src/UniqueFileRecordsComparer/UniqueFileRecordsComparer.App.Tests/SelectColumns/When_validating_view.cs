using System.Collections.Generic;
using FluentAssertions;
using Moq;
using UniqueFileRecordsComparer.App.SelectColumns;
using UniqueFileRecordsComparer.Core;
using UniqueFileRecordsComparer.Core.Readers;
using Xunit;

namespace UniqueFileRecordsComparer.App.Tests.SelectColumns
{
    public class When_validating_view
    {
        private readonly Mock<ISelectColumnsView> _selectColumnsValidViewMock;

        public When_validating_view()
        {
            _selectColumnsValidViewMock = new Mock<ISelectColumnsView>();
            _selectColumnsValidViewMock
                .Setup(view => view.SourceCheckedColumns)
                .Returns(new List<string> { "Column1" });

            _selectColumnsValidViewMock
                .Setup(view => view.TargetCheckedColumns)
                .Returns(new List<string> { "Column1" });
        }

        [Fact]
        public void Given_no_source_columns_selected_Then_returns_false()
        {
            _selectColumnsValidViewMock.Setup(view => view.SourceCheckedColumns).Returns(new List<string>());

            var presenter = new SelectColumnsPresenter(_selectColumnsValidViewMock.Object, Mock.Of<IFileReaderFactory>(), Mock.Of<IRowCollectionComparer>());
            presenter.IsViewValid.Should().BeFalse();
        }

        [Fact]
        public void Given_no_target_columns_selected_Then_returns_false()
        {
            _selectColumnsValidViewMock.Setup(view => view.TargetCheckedColumns).Returns(new List<string>());

            var presenter = new SelectColumnsPresenter(_selectColumnsValidViewMock.Object, Mock.Of<IFileReaderFactory>(), Mock.Of<IRowCollectionComparer>());
            presenter.IsViewValid.Should().BeFalse();
        }

        [Fact]
        public void Given_source_columns_and_target_columns_selected_Then_returns_true()
        {
            var presenter = new SelectColumnsPresenter(_selectColumnsValidViewMock.Object, Mock.Of<IFileReaderFactory>(), Mock.Of<IRowCollectionComparer>());
            presenter.IsViewValid.Should().BeTrue();
        }
    }
}
