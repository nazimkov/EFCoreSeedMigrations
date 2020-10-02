using System;
using System.Collections.Generic;
using EFCoreSeedMigrations.DataAccess.Migrations;
using EFCoreSeedMigrations.DataAccess.Seed;
using EFCoreSeedMigrations.SeedMigration.Seed;

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