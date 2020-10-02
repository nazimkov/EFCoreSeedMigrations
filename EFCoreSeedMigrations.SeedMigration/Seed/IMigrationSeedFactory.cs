using System;

namespace EFCoreSeedMigrations.SeedMigration.Seed
{
    public interface IMigrationSeedFactory
    {
        /// <summary>
        /// Retrieve migration seed instance by provided migration Type
        /// </summary>
        /// <param name="migrationType">Migration class type</param>
        /// <returns>Migration seed instance</returns>
        IMigrationSeed GetMigrationSeed(Type migrationType);
    }
}