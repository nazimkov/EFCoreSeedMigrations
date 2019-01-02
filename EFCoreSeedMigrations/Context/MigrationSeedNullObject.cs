using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreSeedMigrations.Context
{
    public class MigrationSeedNullObject : IMigrationSeed
    {
        public void DownSeed(MigrationBuilder migrationBuilder)
        {
        }

        public void UpSeed(MigrationBuilder migrationBuilder)
        {
        }
    }
}
