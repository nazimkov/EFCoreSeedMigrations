using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreSeedMigrations.CsvImport
{
    public interface IMigrationSeedBuilder
    {
        MigrationBuilder MigrationBuilder { set; }

        void InsertData<TModel>(string filePath, string table, string schema = null) where TModel : class, new();
        void DeleteData<TModel>(string filePath, string table, string schema = null) where TModel : class, new();
        void UpdateData<TModel>(string filePath, string table, string schema = null) where TModel : class, new();
    }
}
