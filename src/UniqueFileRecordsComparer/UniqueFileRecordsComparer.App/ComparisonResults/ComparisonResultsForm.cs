using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UniqueFileRecordsComparer.Core;

namespace UniqueFileRecordsComparer.App.ComparisonResults
{
    public partial class ComparisonResultsForm : Form, IComparisonResultsView
    {
        public ComparisonResultsForm()
        {
            InitializeComponent();
        }

        private IList<Row> _newRows;
        private IList<Row> _deletedRows;

        public IList<Row> NewRows
        {
            get { return _newRows; }
            set
            {
                _newRows = value;
                Presenter.FillGrid(_newRows, NewRowsGrid);
                TotalNewRowsLabel.Text = $@"Total: {_newRows.Count}";
            }
        }

        public IList<Row> DeletedRows
        {
            get { return _deletedRows; }
            set
            {
                _deletedRows = value;
                Presenter.FillGrid(_deletedRows, NewRowsGrid);
                TotalDeletedRowsLabel.Text = $@"Total: {_deletedRows.Count}";
            }
        }

        public ComparisonResultsPresenter Presenter { private get; set; }

        private void ExportNewRowsButton_Click(object sender, System.EventArgs e)
        {
            Presenter.WriteRows(_newRows.ToList());
        }

        private void ExportDeletedRowsButton_Click(object sender, System.EventArgs e)
        {
            Presenter.WriteRows(_newRows.ToList());
        }

        private void ComparisonResultsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
