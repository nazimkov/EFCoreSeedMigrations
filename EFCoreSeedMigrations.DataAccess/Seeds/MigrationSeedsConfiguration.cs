using EFCoreSeedMigrations.DataAccess.Migrations;
using EFCoreSeedMigrations.DataAccess.Seed;
using EFCoreSeedMigrations.SeedMigration.Seed;
using System;
using System.Collections.Generic;

namespace EFCoreSeedMigrations.DataAccess.Seeds
{
    public class MigrationSeedsConfiguration : IMigrationSeedsConfiguration
    {
        public IReadOnlyDictionary<Type, Type> MigrationSeeds => new Dictionary<Type, Type>
        {
            { typeof(InitialMigration), typeof(IntitialMigrationSeed) }
        };
    }
}