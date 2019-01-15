using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreSeedMigrations.CsvImport
{
    public interface IMigrationSeedBuilder
    {
        MigrationBuilder MigrationBuilder { get; set; }

        void InsertData<TModel>(string filePath);
        void DeleteData<TModel>(string filePath);
        void UpdateData<TModel>(string filePath);
    }

    public class MigrationSeedBuilder : IMigrationSeedBuilder
    {
        private readonly ICsvSeedDataReader _csvSeedDataReader;

        public MigrationSeedBuilder(ICsvSeedDataReader csvSeedDataReader)
        {
            _csvSeedDataReader = csvSeedDataReader;
        }

        public MigrationBuilder MigrationBuilder { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void DeleteData<TModel>(string filePath)
        {
            throw new System.NotImplementedException();
        }

        public void InsertData<TModel>(string filePath)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateData<TModel>(string filePath)
        {
            throw new System.NotImplementedException();
        }
    }
}
