namespace UniqueFileRecordsComparer.App.Messages
{
    public class OpenFileMessage
    {
        public string Title { get; set; }
        public string Filter { get; set; }
        public bool CheckFileExists { get; set; }
    }
}
