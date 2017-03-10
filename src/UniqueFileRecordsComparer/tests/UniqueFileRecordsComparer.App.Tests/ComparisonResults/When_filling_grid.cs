using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FluentAssertions;
using Moq;
using UniqueFileRecordsComparer.App.ComparisonResults;
using UniqueFileRecordsComparer.App.MessageHandlers;
using UniqueFileRecordsComparer.Core;
using UniqueFileRecordsComparer.Core.Writers;
using Xunit;

namespace UniqueFileRecordsComparer.App.Tests.ComparisonResults
{
    public class When_filling_grid
    {
        private readonly ComparisonResultsPresenter _presenter;

        public When_filling_grid()
        {
            _presenter = new ComparisonResultsPresenter(Mock.Of<IComparisonResultsView>(), Mock.Of<ISaveFileMessageHandler>(), Mock.Of<ICsvWriterFactory>());
        }

        [Fact]
        public void Given_empty_rows_Then_grid_datasource_is_null()
        {
            var rows = new List<Row>();
            var dataGridView = new DataGridView();

            _presenter.FillGrid(rows, dataGridView);

            dataGridView.DataSource.Should().BeNull();
        }

        [Fact]
        public void Then_headers_and_values_are_set_correctly()
        {
            var rows = new List<Row>
            {
                new Row { new Column("ABC", "12345"), new Column("123", "ABCDEF") },
                new Row { new Column("ABC", "67890"), new Column("123", "GHIJKL") },
            };
            var dataGridView = new DataGridView();

            _presenter.FillGrid(rows, dataGridView);

            var table = dataGridView.DataSource as DataTable;

            dataGridView.DataSource.Should().NotBeNull();
            table.Should().NotBeNull();

            table.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ShouldBeEquivalentTo(new [] { "ABC", "123"});
            table.Rows.Cast<DataRow>().Select(row => row.ItemArray).ShouldBeEquivalentTo(new[] { new [] {"12345", "ABCDEF"}, new [] { "67890", "GHIJKL"} });
        }
    }
}
