using System.Collections.Generic;
using Moq;
using UniqueFileRecordsComparer.App.ComparisonResults;
using UniqueFileRecordsComparer.App.MessageHandlers;
using UniqueFileRecordsComparer.Core;
using UniqueFileRecordsComparer.Core.Writers;
using Xunit;

namespace UniqueFileRecordsComparer.App.Tests.ComparisonResults
{
    public class When_loading
    {
        private readonly Mock<IComparisonResultsView> _viewMock;
        private readonly List<Row> _newRows;
        private readonly List<Row> _deletedRows;

        public When_loading()
        {
            _viewMock = new Mock<IComparisonResultsView>();
            var presenter = new ComparisonResultsPresenter(_viewMock.Object, Mock.Of<ISaveFileMessageHandler>(), Mock.Of<ICsvWriterFactory>());

            _newRows = new List<Row>
            {
                new Row { new Column("abc", "def") }
            };
            _deletedRows = new List<Row>
            {
                new Row { new Column("abc", "def") },
                new Row { new Column("123", "456") },
            };
            presenter.Load(new RowCollectionComparisonResult(_newRows, _deletedRows, new List<Row>()));
        }

        [Fact]
        public void Then_NewRows_are_set_on_view_as_expected()
        {
            _viewMock.VerifySet(view => view.NewRows = _newRows, Times.Once);
        }

        [Fact]
        public void Then_DeletedRows_are_set_on_view_as_expected()
        {
            _viewMock.VerifySet(view => view.DeletedRows = _deletedRows, Times.Once);
        }

        [Fact]
        public void Then_Show_is_called_on_view()
        {
            _viewMock.Verify(view => view.Show(), Times.Once);
        }
    }
}
