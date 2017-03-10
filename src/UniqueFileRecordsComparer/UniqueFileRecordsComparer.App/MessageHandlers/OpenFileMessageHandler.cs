using System.Windows.Forms;

namespace UniqueFileRecordsComparer.App.MessageHandlers
{
    public interface IOpenFileMessageHandler
    {
        DialogResult Handle(OpenFileDialog message);
    }

    public class OpenFileMessageHandler : IOpenFileMessageHandler
    {
        public DialogResult Handle(OpenFileDialog message)
        {
            return message.ShowDialog();
        }
    }
}