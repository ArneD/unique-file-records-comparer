using System;

namespace UniqueFileRecordsComparer.Core.Readers
{
    public static class FileReaderFactory
    {
        public static IFileReader CreateFromFileName(string fileName)
        {
            //TODO: ask delimiter
            if (IsCsvFile(fileName))
            {
                return new CsvReader(fileName, ";");
            }

            if (IsExcelFile(fileName))
            {
                return new ExcelReader(fileName);
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
