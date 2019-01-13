namespace EFCoreSeedMigrations.CsvImport
{
    public interface ICsvSeedDataReader
    {
        (string[], object[,]) ReedSeedData<TModel>(string filePath) where TModel : class, new();
    }
}
