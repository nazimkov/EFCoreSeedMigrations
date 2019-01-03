using EFCoreSeedMigrations.SeedMigration.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System;
using System.Reflection;

namespace EFCoreSeedMigrations.SeedMigration
{
    public class SeedAwareMigrationsAssembly : MigrationsAssembly
    {
        private readonly IHostingEnvironment _env;
        private readonly IMigrationSeedFactory _seedFactory;

        /// <inheritdoc />
        public SeedAwareMigrationsAssembly(
            ICurrentDbContext currentContext,
            IDbContextOptions options,
            IMigrationsIdGenerator idGenerator,
            IDiagnosticsLogger<DbLoggerCategory.Migrations> logger)
            : base(currentContext, options, idGenerator, logger)
        {
            _env = currentContext.Context.GetService<IHostingEnvironment>();
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

                var migrationSeed = _env.IsDevelopment()
                        ? _seedFactory.GetMigrationSeed(migrationClassType)
                        : new MigrationSeedNullObject();

                var instance = (Migration)Activator.CreateInstance(migrationClassType, migrationSeed);
                instance.ActiveProvider = activeProvider;
                return instance;
            }

            return base.CreateMigration(migrationClass, activeProvider);
        }
    }
}