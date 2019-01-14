namespace EFCoreSeedMigrations.CsvImport
{
    public interface ICsvSeedDataReader
    {
        SeedData ReedSeedData<TModel>(string filePath) where TModel : class, new();
    }
}
