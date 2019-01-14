namespace EFCoreSeedMigrations.CsvImport
{
    public class SeedData
    {
        public string[] Headers { get; }
        public object[,] Records { get; }

        public SeedData(string[] headers, object[,] records)
        {
            Headers = headers;
            Records = records;
        }
    }
}
