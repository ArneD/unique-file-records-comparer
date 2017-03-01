using System.Windows.Forms;

namespace UniqueFileRecordsComparer.App.Messages
{
    public interface IOpenFileMessageHandler
    {
        string Handle(OpenFileMessage message);
    }

    public class OpenFileMessageHandler : IOpenFileMessageHandler
    {
        public string Handle(OpenFileMessage message)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.CheckFileExists = message.CheckFileExists;
                dialog.Title = message.Title;
                dialog.Filter = message.Filter;

                var result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                    return dialog.FileName;
            }
            return "";
        }
    }
}