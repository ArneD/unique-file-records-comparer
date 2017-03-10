using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UniqueFileRecordsComparer.App.ComparisonResults;
using UniqueFileRecordsComparer.App.Messages;
using UniqueFileRecordsComparer.Core.Writers;

namespace UniqueFileRecordsComparer.App.SelectColumns
{
    public partial class SelectColumnsForm : Form, ISelectColumnsView
    {
        public SelectColumnsForm()
        {
            InitializeComponent();
        }

        private async void Compare_Click(object sender, System.EventArgs e)
        {
            if (Presenter.IsViewValid)
            {
                var comparisonResult = await Presenter.CompareFiles();
                var resultForm = new ComparisonResultsForm();
                var presenter = new ComparisonResultsPresenter(resultForm, new SaveFileMessageHandler(), new CsvWriterFactory());
                presenter.Load(comparisonResult);
                Hide();
            }
            else
            {
                MessageBox.Show("Please select at least one column from source and target to compare", "Select columns", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public IEnumerable<string> SourceColumns
        {
            get { return SourceColumnsCheckList.Items.Cast<string>(); }
            set
            {
                SourceColumnsCheckList.Items.Clear();
                foreach (var val in value)
                {
                    SourceColumnsCheckList.Items.Add(val);
                }
            }
        }

        public IEnumerable<string> TargetColumns
        {
            get { return TargetColumnsCheckList.Items.Cast<string>(); }
            set
            {
                TargetColumnsCheckList.Items.Clear();
                foreach (var val in value)
                {
                    TargetColumnsCheckList.Items.Add(val);
                }
            }
        }

        public IEnumerable<string> SourceCheckedColumns => SourceColumnsCheckList.CheckedItems.Cast<string>();

        public IEnumerable<string> TargetCheckedColumns => TargetColumnsCheckList.CheckedItems.Cast<string>();

        public SelectColumnsPresenter Presenter { private get; set; }
    }
}
