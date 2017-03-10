using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Windows.Forms;
using UniqueFileRecordsComparer.App.MessageHandlers;
using UniqueFileRecordsComparer.Core;
using UniqueFileRecordsComparer.Core.Writers;

namespace UniqueFileRecordsComparer.App.ComparisonResults
{
    public class ComparisonResultsPresenter
    {
        private readonly IComparisonResultsView _view;
        private readonly ISaveFileMessageHandler _saveFileMessageHandler;
        private readonly ICsvWriterFactory _csvWriterFactory;

        public ComparisonResultsPresenter(IComparisonResultsView view, ISaveFileMessageHandler saveFileMessageHandler, ICsvWriterFactory csvWriterFactory)
        {
            _view = view;
            _saveFileMessageHandler = saveFileMessageHandler;
            _csvWriterFactory = csvWriterFactory;
            _view.Presenter = this;
        }

        public void Load(RowCollectionComparisonResult comparisonResult)
        {
            _view.NewRows = comparisonResult.NewRows.ToList();
            _view.DeletedRows = comparisonResult.DeletedRows.ToList();

            _view.Show();
        }

        public void FillGrid(IList<Row> rows, DataGridView grid)
        {
            var firstRow = rows.FirstOrDefault();
            var table = new DataTable();
            if (firstRow != null)
            {
                foreach (var column in firstRow)
                {
                    table.Columns.Add(column.Header);
                }

                foreach (var newRow in rows)
                {
                    var row = table.NewRow();
                    foreach (var column in newRow)
                    {
                        row[column.Header] = column.Value;
                    }
                    table.Rows.Add(row);
                }

                grid.DataSource = table;
            }
        }

        public void WriteRows(IList<Row> rows)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.CreatePrompt = true;
                saveDialog.OverwritePrompt = true;
                saveDialog.Filter = @"Csv |*.csv";

                var dialogResult =_saveFileMessageHandler.Handle(saveDialog);

                if (dialogResult == DialogResult.OK)
                {
                    using (var writer = _csvWriterFactory.Create(new FileInfoWrapper(new FileInfo(saveDialog.FileName))))
                    {
                        CsvWriterHelper.WriteToCsv(writer, rows);
                    }
                }
            }
        }
    }
}
