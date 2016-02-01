using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UniqueFileRecordsComparer.Core;

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
    }
}
