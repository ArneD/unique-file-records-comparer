using System;
using System.Reflection;
using System.Windows.Forms;
using DryIoc;
using UniqueFileRecordsComparer.App.ComparisonResults;
using UniqueFileRecordsComparer.App.MessageHandlers;
using UniqueFileRecordsComparer.App.SelectColumns;
using UniqueFileRecordsComparer.App.SelectFiles;
using UniqueFileRecordsComparer.Core;
using UniqueFileRecordsComparer.Core.Readers;

namespace UniqueFileRecordsComparer.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = new Container(Rules.Default, new AsyncExecutionFlowScopeContext());
            container.RegisterMany(new[] { typeof(IRowCollectionComparer).Assembly }, type => type.IsInterface);

            container.Register<ISelectFilesView, SelectFilesForm>(setup: Setup.With(trackDisposableTransient: true));
            container.Register<ISelectColumnsView, SelectColumnsForm>(setup: Setup.With(trackDisposableTransient: true));
            container.Register<IComparisonResultsView, ComparisonResultsForm>(setup: Setup.With(trackDisposableTransient: true));
            container.Register<SelectFilesPresenter>();
            container.Register<SelectColumnsPresenter>();
            container.Register<ComparisonResultsPresenter>();
            container.Register<IOpenFileMessageHandler, OpenFileMessageHandler>();
            container.Register<ISaveFileMessageHandler, SaveFileMessageHandler>();

            var form = container.Resolve<ISelectFilesView>() as SelectFilesForm;
            Application.Run(form);
        }
    }
}
