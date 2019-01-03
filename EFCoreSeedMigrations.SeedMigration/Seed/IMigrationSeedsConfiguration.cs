using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSeedMigrations.SeedMigration.Seed
{
    public interface IMigrationSeedsConfiguration
    {
        IReadOnlyDictionary<Type, Type> MigrationSeeds { get; }
    }
}
