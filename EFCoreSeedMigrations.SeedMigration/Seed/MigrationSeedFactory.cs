using System;

namespace EFCoreSeedMigrations.SeedMigration.Seed
{
    public class MigrationSeedFactory : IMigrationSeedFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMigrationSeedsConfiguration _seedsConfiguration;

        public MigrationSeedFactory(IServiceProvider serviceProvider, IMigrationSeedsConfiguration seedsConfiguration)
        {
            _serviceProvider = serviceProvider;
            _seedsConfiguration = seedsConfiguration;
        }

        /// <inheritdoc />
        public IMigrationSeed GetMigrationSeed(Type migrationType)
        {
            var seeds = _seedsConfiguration.MigrationSeeds;

            if (!seeds.ContainsKey(migrationType))
            {
                throw new ArgumentException($"Cannot find migration type {nameof(migrationType)}");
            }

            return _serviceProvider.GetService(seeds[migrationType]) as IMigrationSeed;
        }
    }
}