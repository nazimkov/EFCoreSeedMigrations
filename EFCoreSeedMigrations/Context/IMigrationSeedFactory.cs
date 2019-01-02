using System;
using System.Collections.Generic;

namespace EFCoreSeedMigrations.Context
{
    public interface IMigrationSeedFactory
    {
        IMigrationSeed GetMigrationSeed(Type migrationType);
    }
}