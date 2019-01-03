using EFCoreSeedMigrations.SeedMigration.Seed;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSeedMigrations.SeedMigration
{
    public static class MigrationsSeedServiceCollectionExctensions
    {
        public static IServiceCollection AddEfMigrationSeeds<TConfiguration>(this IServiceCollection services)
            where TConfiguration : class, IMigrationSeedsConfiguration
        {
            services.AddScoped<IMigrationSeedFactory, MigrationSeedFactory>();
            services.AddSingleton<IMigrationSeedsConfiguration, TConfiguration>();

            return services;
        }
    }
}
