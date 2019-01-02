using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreSeedMigrations.Context
{
    public interface IMigrationSeed
    {
        void UpSeed(MigrationBuilder migrationBuilder);
        void DownSeed(MigrationBuilder migrationBuilder);
    }
}
