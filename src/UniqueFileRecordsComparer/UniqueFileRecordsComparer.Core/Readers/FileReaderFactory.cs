using System;
using System.IO.Abstractions;

namespace UniqueFileRecordsComparer.Core.Readers
{
    public class FileReaderFactory : IFileReaderFactory
    {
        public IFileReader CreateFromFileName(FileInfoBase fileInfoBase)
        {
            if (IsCsvFile(fileInfoBase.FullName))
            {
                return new CsvReader(fileInfoBase);
            }

            if (IsExcelFile(fileInfoBase.FullName))
            {
                return new ExcelReader(fileInfoBase);
            }

            throw new InvalidOperationException();
        }

        private static bool IsExcelFile(string fileName)
        {
            return fileName.EndsWith(".xlsx");
        }

        private static bool IsCsvFile(string fileName)
        {
            return fileName.EndsWith(".csv");
        }
    }
}
