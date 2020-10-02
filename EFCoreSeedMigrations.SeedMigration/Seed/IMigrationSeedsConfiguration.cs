using System;
using System.Collections.Generic;

namespace EFCoreSeedMigrations.SeedMigration.Seed
{
    public interface IMigrationSeedsConfiguration
    {
        IReadOnlyDictionary<Type, Type> MigrationSeeds { get; }
    }
}