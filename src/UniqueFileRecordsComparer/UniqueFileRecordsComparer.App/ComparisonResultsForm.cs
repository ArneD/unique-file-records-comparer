using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UniqueFileRecordsComparer.Core;
using UniqueFileRecordsComparer.Core.Writers;

namespace UniqueFileRecordsComparer.App
{
    public partial class ComparisonResultsForm : Form
    {
        private readonly RowCollectionComparisonResult _comparisonResult;

        public ComparisonResultsForm(RowCollectionComparisonResult comparisonResult)
        {
            _comparisonResult = comparisonResult;
            InitializeComponent();

            FillGrid(_comparisonResult.NewRows.ToList(), NewRowsGrid);
            FillGrid(_comparisonResult.DeletedRows.ToList(), DeletedRowsGrid);

            TotalNewRowsLabel.Text = $@"Total: {_comparisonResult.NewRows.Count()}";
            TotalDeletedRowsLabel.Text = $@"Total: {_comparisonResult.DeletedRows.Count()}";
        }

        private static void FillGrid(IList<Row> rows, DataGridView grid)
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

        private void ExportNewRowsButton_Click(object sender, System.EventArgs e)
        {
            WriteRows(_comparisonResult.NewRows.ToList());
        }

        private void ExportDeletedRowsButton_Click(object sender, System.EventArgs e)
        {
            WriteRows(_comparisonResult.DeletedRows.ToList());
        }

        private void WriteRows(IList<Row> rows)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.CreatePrompt = true;
                saveDialog.OverwritePrompt = true;
                saveDialog.Filter = @"Csv |*.csv";

                var dialogResult = saveDialog.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    using (var writer = CsvWriter.Create(saveDialog.FileName))
                    {
                        CsvWriter.WriteToCsv(writer, rows);
                    }
                }
            }
        }

        private void ComparisonResultsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
