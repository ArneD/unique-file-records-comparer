using System;
using System.IO;
using FluentAssertions;
using Xunit;


namespace UniqueFileRecordsComparer.Core.IntegrationTests
{
    public class CompareTwoFieldWithOneFieldTests
    {
        const string twoFieldFilePath = "TestFiles\\TwoFieldsCsvWithHeaders.csv";
        const string oneFieldFilePath = "TestFiles\\OneFieldXlsxWithHeaders.xlsx";

        [Fact]
        public void Test()
        {
            CheckFilesExist();

            var twoFieldFileFields = new CsvReader(twoFieldFilePath).Read();

            twoFieldFileFields.Should().NotBeNull();
            twoFieldFileFields.Count.Should().BeGreaterThan(0);
        }

        private static void CheckFilesExist()
        {
            Assert.True(File.Exists(twoFieldFilePath));
            Assert.True(File.Exists(oneFieldFilePath));
        }
    }
}
