using System;
using System.Collections.Generic;

namespace EFCoreSeedMigrations.SeedMigration.Seed
{
    public interface IMigrationSeedsConfiguration
    {
        Type GetMigrationSeedType(Type migrationType);
    }
}