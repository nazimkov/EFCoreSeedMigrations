using EFCoreSeedMigrations.SeedMigration.Seed;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreSeedMigrations.SeedMigration
{
    public static class MigrationsSeedServiceCollectionExtensions
    {
        public static IServiceCollection AddEfMigrationSeeds<TConfiguration, TSpecification>(this IServiceCollection services)
            where TConfiguration : class, IMigrationSeedsConfiguration
            where TSpecification : class, IMigrationSeedsApplicabilitySpecification
        {
            services.AddScoped<IMigrationSeedFactory, MigrationSeedFactory>();
            services.AddSingleton<IMigrationSeedsApplicabilitySpecification, TSpecification>();
            services.AddSingleton<IMigrationSeedsConfiguration, TConfiguration>();

            return services;
        }
    }
}