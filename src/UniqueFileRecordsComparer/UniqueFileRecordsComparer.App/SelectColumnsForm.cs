using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Windows.Forms;
using UniqueFileRecordsComparer.Core;
using UniqueFileRecordsComparer.Core.Readers;

namespace UniqueFileRecordsComparer.App
{
    public partial class SelectColumnsForm : Form
    {
        private readonly RowCollection _sourceRowCollection;
        private readonly RowCollection _targetRowCollection;

        public SelectColumnsForm(ComparerArguments comparerArguments)
        {
            InitializeComponent();

            using (var sourceReader = FileReaderFactory.CreateFromFileName(new FileInfoWrapper(new FileInfo(comparerArguments.SourceFilePath))))
            {
                _sourceRowCollection = sourceReader.Read();
            }

            using (var targetReader = FileReaderFactory.CreateFromFileName(new FileInfoWrapper(new FileInfo(comparerArguments.TargetFilePath))))
            {
                _targetRowCollection = targetReader.Read();
            }

            AddColumnsToCheckList(SourceColumnsCheckList, _sourceRowCollection);
            AddColumnsToCheckList(TargetColumnsCheckList, _targetRowCollection);
        }

        private static void AddColumnsToCheckList(CheckedListBox checkList, RowCollection rowCollection)
        {
            foreach (var columnHeader in rowCollection.GetColumnHeaders())
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
            _sourceRowCollection.ColumnHeadersToCompare = SourceColumnsCheckList.CheckedItems.Cast<string>().ToList();
            _targetRowCollection.ColumnHeadersToCompare = TargetColumnsCheckList.CheckedItems.Cast<string>().ToList();

            var comparer = new RowCollectionComparer(_sourceRowCollection, _targetRowCollection);
            return comparer.GetCollectionComparisonResult();
        }
    }
}
