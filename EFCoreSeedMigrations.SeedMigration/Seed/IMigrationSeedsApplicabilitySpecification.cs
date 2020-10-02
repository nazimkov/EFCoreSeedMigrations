namespace EFCoreSeedMigrations.SeedMigration.Seed
{
    public interface IMigrationSeedsApplicabilitySpecification
    {
        bool ShouldSeed { get; }
    }
}