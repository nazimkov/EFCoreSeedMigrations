using System;

namespace EFCoreSeedMigrations.SeedMigration.Seed
{
    public class MigrationSeedFactory : IMigrationSeedFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMigrationSeedsConfiguration _seedsConfiguration;

        public MigrationSeedFactory(IServiceProvider serviceProvider, IMigrationSeedsConfiguration seedsConfiguration)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _seedsConfiguration = seedsConfiguration ?? throw new ArgumentNullException(nameof(seedsConfiguration));
        }

        /// <inheritdoc />
        public IMigrationSeed GetMigrationSeed(Type migrationType)
        {
            var migrationSeedType = _seedsConfiguration.GetMigrationSeedType(migrationType);
            return (IMigrationSeed)_serviceProvider.GetService(migrationSeedType);
        }
    }
}