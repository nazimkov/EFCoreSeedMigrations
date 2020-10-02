using EFCoreSeedMigrations.SeedMigration.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace EFCoreSeedMigrations.API.Migrations
{
    internal sealed class MigrationSeedsApplicabilitySpecification : IMigrationSeedsApplicabilitySpecification
    {
        private readonly IWebHostEnvironment _environment;

        public MigrationSeedsApplicabilitySpecification(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public bool ShouldSeed => _environment.IsDevelopment();
    }
}