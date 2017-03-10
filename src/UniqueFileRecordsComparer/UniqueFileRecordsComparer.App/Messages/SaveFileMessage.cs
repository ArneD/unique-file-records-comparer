using System.Windows.Forms;

namespace UniqueFileRecordsComparer.App.Messages
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
