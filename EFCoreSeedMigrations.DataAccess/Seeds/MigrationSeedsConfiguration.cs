using System;
using System.Collections.Generic;
using EFCoreSeedMigrations.DataAccess.Migrations;
using EFCoreSeedMigrations.DataAccess.Seed;
using EFCoreSeedMigrations.SeedMigration.Seed;

namespace EFCoreSeedMigrations.DataAccess.Seeds
{
    public class MigrationSeedsConfiguration : IMigrationSeedsConfiguration
    {
        private readonly IReadOnlyDictionary<Type, Type> _migrationSeeds = new Dictionary<Type, Type>
        {
            [typeof(InitialMigration)] = typeof(IntitialMigrationSeed)
        };

        public Type GetMigrationSeedType(Type migrationType)
        {
            if (migrationType == null) throw new ArgumentNullException(nameof(migrationType));

            if (!_migrationSeeds.ContainsKey(migrationType))
            {
                throw new ArgumentException($"Cannot find migration type {nameof(migrationType)}");
            }

            return _migrationSeeds[migrationType];
        }
    }
}