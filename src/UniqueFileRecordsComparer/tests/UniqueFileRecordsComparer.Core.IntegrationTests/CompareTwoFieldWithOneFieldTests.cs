﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using UniqueFileRecordsComparer.Core.Readers;
using Xunit;

namespace UniqueFileRecordsComparer.Core.IntegrationTests
{
    public class CompareTwoFieldWithOneFieldTests
    {
        private const string CsvFileWithHeadersPath = "TestFiles\\TwoFieldsCsvWithHeaders.csv";
        private const string ExcelFileWithHeadersPath = "TestFiles\\OneFieldXlsxWithHeaders.xlsx";

        [Fact]
        public void Test()
        {
            CheckFilesExist();

            var csvRows = new CsvReader(CsvFileWithHeadersPath, ";").Read(true).ToList();
            csvRows.Should().NotBeEmpty();

            var excelRows = new ExcelReader(ExcelFileWithHeadersPath).Read(true).ToList();
            excelRows.Should().NotBeEmpty();

            var compareTwoFields = new List<string> { "First name", "Last name" };
            var compareOneField = new List<string> { "Name" };

            var csvRowCollection = new RowCollection(csvRows, compareTwoFields);
            var excelRowCollection = new RowCollection(excelRows, compareOneField);

            var rowComparer = new RowCollectionComparer(csvRowCollection, excelRowCollection);
            var result = rowComparer.GetCollectionComparisonResult();

            result.NewRows.ShouldAllBeEquivalentTo(new List<Row>
            {
                new Row
                {
                    new Column("Nr", "2"),
                    new Column("Name", "New name"),
                    new Column("Address", "Test street 123")
                }
            });

            result.DeletedRows.ShouldAllBeEquivalentTo(new List<Row>
            {
                new Row
                {
                    new Column("ID", "12"),
                    new Column("First name", "Deleted"),
                    new Column("Last name", "Name"),
                    new Column("Address", "Hell 109")
                }
            });
        }

        private static void CheckFilesExist()
        {
            Assert.True(File.Exists(CsvFileWithHeadersPath));
            Assert.True(File.Exists(ExcelFileWithHeadersPath));
        }
    }
}
