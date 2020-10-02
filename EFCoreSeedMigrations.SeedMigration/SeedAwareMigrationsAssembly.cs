using System;
using System.Reflection;
using EFCoreSeedMigrations.SeedMigration.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

namespace EFCoreSeedMigrations.SeedMigration
{
#pragma warning disable EF1001 // Internal EF Core API usage.

    public class SeedAwareMigrationsAssembly : MigrationsAssembly
#pragma warning restore EF1001 // Internal EF Core API usage.
    {
        private readonly IMigrationSeedsApplicabilitySpecification _seedSpecs;
        private readonly IMigrationSeedFactory _seedFactory;

        /// <inheritdoc />
        public SeedAwareMigrationsAssembly(
            ICurrentDbContext currentContext,
            IDbContextOptions options,
            IMigrationsIdGenerator idGenerator,
            IDiagnosticsLogger<DbLoggerCategory.Migrations> logger)
            : base(currentContext, options, idGenerator, logger)
        {
            _seedSpecs = currentContext.Context.GetService<IMigrationSeedsApplicabilitySpecification>();
            _seedFactory = currentContext.Context.GetService<IMigrationSeedFactory>();
        }

        /// <inheritdoc />
        public override Migration CreateMigration(TypeInfo migrationClass, string activeProvider)
        {
            if (activeProvider == null)
            {
                throw new ArgumentNullException(nameof(activeProvider));
            }

            var hasCtorWithSeed = migrationClass.GetConstructor(new[] { typeof(IMigrationSeed) }) != null;

            if (hasCtorWithSeed)
            {
                var migrationClassType = migrationClass.AsType();

                var migrationSeed = _seedSpecs.ShouldSeed
                        ? _seedFactory.GetMigrationSeed(migrationClassType)
                        : new MigrationSeedNullObject();

                var instance = (Migration)Activator.CreateInstance(migrationClassType, migrationSeed);
                instance.ActiveProvider = activeProvider;
                return instance;
            }

#pragma warning disable EF1001 // Internal EF Core API usage.
            return base.CreateMigration(migrationClass, activeProvider);
#pragma warning restore EF1001 // Internal EF Core API usage.
        }
    }
}