using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UniqueFileRecordsComparer.Core;
using UniqueFileRecordsComparer.Core.Readers;

namespace UniqueFileRecordsComparer.App
{
    public partial class SelectColumnsForm : Form
    {
        private readonly IList<Row> _sourceRows;
        private readonly IList<Row> _targetRows;

        public SelectColumnsForm(ComparerArguments comparerArguments)
        {
            InitializeComponent();

            var sourceReader = FileReaderFactory.CreateFromFileName(comparerArguments.SourceFilePath);
            var targetReader = FileReaderFactory.CreateFromFileName(comparerArguments.TargetFilePath);

            _sourceRows = sourceReader.Read(true).ToList();
            _targetRows = targetReader.Read(true).ToList();

            AddColumnsToCheckList(SourceColumnsCheckList, _sourceRows.First());
            AddColumnsToCheckList(TargetColumnsCheckList, _targetRows.First());
        }

        private static void AddColumnsToCheckList(CheckedListBox checkList, Row row)
        {
            foreach (var columnHeader in row.GetColumnHeaders())
            {
                checkList.Items.Add(columnHeader);
            }
        }

        private void Compare_Click(object sender, System.EventArgs e)
        {
            if (IsFormValid())
            {
                var comparisonResult = CompareFiles();
                var resultForm = new ComparisonResultsForm(comparisonResult);
                resultForm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Please select at least one column from source and target to compare", "Select columns");
            }
        }

        private bool IsFormValid()
        {
            return SourceColumnsCheckList.CheckedItems.Count > 0 &&
                   TargetColumnsCheckList.CheckedItems.Count > 0;
        }

        private RowCollectionComparisonResult CompareFiles()
        {
            var sourceRowCollection = new RowCollection(_sourceRows, SourceColumnsCheckList.CheckedItems.Cast<string>().ToList());
            var targetRowCollection = new RowCollection(_targetRows, TargetColumnsCheckList.CheckedItems.Cast<string>().ToList());

            var comparer = new RowComparer(sourceRowCollection, targetRowCollection);
            return comparer.GetCollectionComparisonResult();
        }
    }
}
