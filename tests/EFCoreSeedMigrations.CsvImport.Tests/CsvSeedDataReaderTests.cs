using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit;

namespace EFCoreSeedMigrations.CsvImport.Tests
{
    public class CsvSeedDataReaderTests
    {
        private readonly CsvSeedDataReader _csvSeedDataReader;

        public CsvSeedDataReaderTests()
        {
            _csvSeedDataReader = new CsvSeedDataReader();
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        [Fact]
        public void ReedSeedData_ExistedFileWithValidData_ReturnsHeadersAndObjects()
        {
            // Arrange
            var records = new List<Foo>
            {
                new Foo { Id = 1, Name = "one" },
            };
            var path = AssemblyDirectory + "\\file.csv";

            // Act
            WtiteSeedToFile(path, records);
            var (headers, resultObjects) = _csvSeedDataReader.ReedSeedData<Foo>(path);

            // Assert

            Assert.NotNull(resultObjects);
            Assert.NotNull(headers);
        }

        private void WtiteSeedToFile(string path, IEnumerable<Foo> records)
        {
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteHeader<Foo>();
                csv.WriteRecords(records);
            }
        }

        public class Foo
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}