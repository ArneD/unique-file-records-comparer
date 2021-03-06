﻿using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using UniqueFileRecordsComparer.Core;
using UniqueFileRecordsComparer.Core.Readers;

namespace UniqueFileRecordsComparer.App.SelectColumns
{
    public class SelectColumnsPresenter
    {
        private RowCollection _sourceRowCollection;
        private RowCollection _targetRowCollection;
        private readonly ISelectColumnsView _view;
        private readonly IFileReaderFactory _fileReaderFactory;
        private readonly IRowCollectionComparer _rowCollectionComparer;

        public SelectColumnsPresenter(ISelectColumnsView view, IFileReaderFactory fileReaderFactory, IRowCollectionComparer rowCollectionComparer)
        {
            _view = view;
            _fileReaderFactory = fileReaderFactory;
            _rowCollectionComparer = rowCollectionComparer;
            _view.Presenter = this;
        }

        public void Load(ComparerArguments comparerArguments)
        {
            var sourceReader =
               _fileReaderFactory.CreateFromFileName(new FileInfoWrapper(new FileInfo(comparerArguments.SourceFilePath)));
            var targetReader =
                _fileReaderFactory.CreateFromFileName(new FileInfoWrapper(new FileInfo(comparerArguments.TargetFilePath)));

            _sourceRowCollection = sourceReader.Read(comparerArguments.SourceFileTabIndex);
            _targetRowCollection = targetReader.Read(comparerArguments.TargetFileTabIndex);

            _view.SourceColumns = _sourceRowCollection.GetColumnHeaders();
            _view.TargetColumns = _targetRowCollection.GetColumnHeaders();
            _view.Show();
        }

        public bool IsViewValid => _view.SourceCheckedColumns.Any() && _view.TargetCheckedColumns.Any();

        public Task<RowCollectionComparisonResult> CompareFiles()
        {
            _sourceRowCollection.ColumnHeadersToCompare = _view.SourceCheckedColumns.ToList();
            _targetRowCollection.ColumnHeadersToCompare = _view.TargetCheckedColumns.ToList();

            return Task.Run(() => _rowCollectionComparer.GetCollectionComparisonResult(_sourceRowCollection, _targetRowCollection));
        }
    }
}
