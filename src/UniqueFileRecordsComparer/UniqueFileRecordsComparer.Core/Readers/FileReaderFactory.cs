using System;
using System.IO;
using System.IO.Abstractions;
using CsvHelper.Configuration;
using Excel;

namespace UniqueFileRecordsComparer.Core.Readers
{
    public static class FileReaderFactory
    {
        public static IFileReader CreateFromFileName(FileInfoBase fileInfoBase)
        {
            if (IsCsvFile(fileInfoBase.FullName))
            {
                var reader = new CsvHelper.CsvReader(new StreamReader(fileInfoBase.OpenRead()), new CsvConfiguration
                {
                    HasHeaderRecord = true,
                    Delimiter = ";"
                });

                return new CsvReader(reader);
            }

            if (IsExcelFile(fileInfoBase.FullName))
            {
                var excelReader = ExcelReaderFactory.CreateOpenXmlReader(fileInfoBase.Open(FileMode.Open, FileAccess.Read));
                excelReader.IsFirstRowAsColumnNames = true;
                return new ExcelReader(excelReader);
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
