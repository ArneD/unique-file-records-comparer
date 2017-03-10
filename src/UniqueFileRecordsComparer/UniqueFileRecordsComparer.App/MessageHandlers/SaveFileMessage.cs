using System.Windows.Forms;

namespace UniqueFileRecordsComparer.App.MessageHandlers
{
    public interface ISaveFileMessageHandler
    {
        DialogResult Handle(SaveFileDialog dialog);
    }

    public class SaveFileMessageHandler : ISaveFileMessageHandler
    {
        public DialogResult Handle(SaveFileDialog dialog)
        {
            return dialog.ShowDialog();
        }
    }
}
