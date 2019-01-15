using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreSeedMigrations.CsvImport
{
    public class MigrationSeedBuilder : IMigrationSeedBuilder
    {
        private readonly ICsvSeedDataReader _csvSeedDataReader;

        public MigrationSeedBuilder(ICsvSeedDataReader csvSeedDataReader)
        {
            _csvSeedDataReader = csvSeedDataReader;
        }

        public MigrationBuilder MigrationBuilder { private get; set; }

        public void DeleteData<TModel>(string filePath, string table, string schema = null) where TModel : class, new()
        {
            throw new System.NotImplementedException();
        }

        public void InsertData<TModel>(string filePath, string table, string schema = null) where TModel : class, new()
        {
            var seedData = _csvSeedDataReader.ReedSeedData<TModel>(filePath);
            if (!seedData.IsAnyData())
            {
                return;
            }

            MigrationBuilder.InsertData(table, seedData.Headers, seedData.Records, schema);
        }

        public void UpdateData<TModel>(string filePath, string table, string schema = null) where TModel : class, new()
        {
            throw new System.NotImplementedException();
        }


    }
}
