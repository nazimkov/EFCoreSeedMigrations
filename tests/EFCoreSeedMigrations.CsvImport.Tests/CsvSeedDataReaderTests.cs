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
            var seedData = _csvSeedDataReader.ReedSeedData<Foo>(path);

            // Assert
            Assert.NotNull(seedData.Headers);
            Assert.NotNull(seedData.Records);
            Assert.Equal(new string[] { nameof(Foo.Id), nameof(Foo.Name) }, seedData.Headers);
            Assert.Equal(GetObjects(records), seedData.Records);
        }


        [Fact]
        public void ReedSeedData_TypeWithoutProperties_ReturnsEmptyObjectsAndHeaders()
        {
            // Arrange
            var records = new Foo[]
            {
                new Foo()
            };

            var path = AssemblyDirectory + "\\file.csv";

            // Act
            WtiteSeedToFile(path, records);
            var seedData = _csvSeedDataReader.ReedSeedData<EmptyFoo>(path);

            // Assert
            Assert.False(seedData.IsAnyData());
        }



        private void WtiteSeedToFile<Type>(string path, IEnumerable<Type> records)
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

        private class EmptyFoo { };
    }
}