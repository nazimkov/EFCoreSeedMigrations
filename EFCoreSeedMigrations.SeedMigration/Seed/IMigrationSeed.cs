using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreSeedMigrations.SeedMigration.Seed
{
    public interface IMigrationSeed
    {
        void UpSeed(MigrationBuilder migrationBuilder);
        void DownSeed(MigrationBuilder migrationBuilder);
    }
}
