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
}
