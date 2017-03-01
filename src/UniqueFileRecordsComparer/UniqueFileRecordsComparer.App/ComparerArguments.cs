namespace UniqueFileRecordsComparer.App
{
    public class ComparerArguments
    {
        public string SourceFilePath { get; set; }
        public string TargetFilePath { get; set; }

        public int SourceFileTabIndex { get; set; }
        public int TargetFileTabIndex { get; set; }

        public bool IsValid => !string.IsNullOrWhiteSpace(SourceFilePath) && !string.IsNullOrWhiteSpace(TargetFilePath);
    }
}