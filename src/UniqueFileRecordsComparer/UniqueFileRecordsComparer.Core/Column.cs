namespace UniqueFileRecordsComparer.Core
{
    public class Column
    {
        public Column(string header, string value)
        {
            Header = header;
            Value = value;
        }

        public string Header { get; }
        public string Value { get; }
    }
}
