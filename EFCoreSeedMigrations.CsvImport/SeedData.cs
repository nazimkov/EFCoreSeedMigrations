using System.Linq;

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

        public bool IsAnyData()
        {
            return Headers != null && Records != null
                && Headers.Any() && Records.GetLength(0) > 0 && Records.GetLength(1)> 0;
        }

    }
}
