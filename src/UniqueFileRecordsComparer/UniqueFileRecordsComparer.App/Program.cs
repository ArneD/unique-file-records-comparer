using System;
using System.Windows.Forms;
using UniqueFileRecordsComparer.App.MessageHandlers;
using UniqueFileRecordsComparer.App.SelectFiles;
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

            //TODO: IOC
            var view = new SelectFilesForm();
            var presenter = new SelectFilesPresenter(view, new OpenFileMessageHandler(), new FileReaderFactory());

            Application.Run(view);
        }
    }
}
