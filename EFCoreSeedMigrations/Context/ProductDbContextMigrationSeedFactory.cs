using EFCoreSeedMigrations.Migrations;
using EFCoreSeedMigrations.Seeds;
using System;
using System.Collections.Generic;

namespace EFCoreSeedMigrations.Context
{
    public class ProductDbContextMigrationSeedFactory : IMigrationSeedFactory
    {
        public ProductDbContextMigrationSeedFactory(IServiceProvider serviceProvider)
        {
            _migrationSeeds = new Lazy<IReadOnlyDictionary<Type, Type>>(GetMigrationSeeds);
            this._serviceProvider = serviceProvider;
        }

        private readonly Lazy<IReadOnlyDictionary<Type, Type>> _migrationSeeds;
        private readonly IServiceProvider _serviceProvider;

        private IReadOnlyDictionary<Type, Type> GetMigrationSeeds()
        {
            return new Dictionary<Type, Type>
            {
                {typeof(InitialMigration), typeof(IntitialMigrationSeed) }
            };
        }

        public IMigrationSeed GetMigrationSeed(Type migrationType)
        {
            var seeds = _migrationSeeds.Value;

            if (!seeds.ContainsKey(migrationType))
            {
                throw new ArgumentException($"Cannot find migration type {nameof(migrationType)}");
            }

            return _serviceProvider.GetService(seeds[migrationType]) as IMigrationSeed;
        }
    }
}
