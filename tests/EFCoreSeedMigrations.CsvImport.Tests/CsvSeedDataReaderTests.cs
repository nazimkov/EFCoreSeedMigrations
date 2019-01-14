using CsvHelper;
using System.Collections.Generic;
using System.IO;
using Xunit;
using static EFCoreSeedMigrations.CsvImport.Tests.TestFilesHelper.AssemblyHelper;

namespace EFCoreSeedMigrations.CsvImport.Tests
{
    public class CsvSeedDataReaderTests
    {
        private readonly CsvSeedDataReader _csvSeedDataReader;

        public CsvSeedDataReaderTests()
        {
            _csvSeedDataReader = new CsvSeedDataReader();
        }


        [Fact]
        public void ReedSeedData_ExistedFileWithValidData_ReturnsHeadersAndObjects()
        {
            // Arrange
            var records = new Foo[]
            {
                new Foo { Id = 1, Name = "one" },
                new Foo { Id = 2, Name = "second" },
            };

            var path = AssemblyDirectory + "\\file.csv";

            // Act
            WtiteSeedToFile(path, records);
            var (headers, resultObjects) = _csvSeedDataReader.ReedSeedData<Foo>(path);

            // Assert
            Assert.NotNull(resultObjects);
            Assert.NotNull(headers);
            Assert.Equal(new string[] { nameof(Foo.Id), nameof(Foo.Name) }, headers);
            Assert.Equal(GetObjects(records), resultObjects);
        }

        private void WtiteSeedToFile(string path, IEnumerable<Foo> records)
        {
            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(records);
            }
        }

        private object[,] GetObjects(Foo[] records)
        {
            var result = new object[records.Length, 2];
            for (int i = 0; i < records.Length; i++)
            {
                result[i, 0] = records[i].Id;
                result[i, 1] = records[i].Name;
            }

            return result;
        }

        private class Foo
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}