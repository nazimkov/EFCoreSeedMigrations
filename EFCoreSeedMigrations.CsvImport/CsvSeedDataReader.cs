using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EFCoreSeedMigrations.CsvImport
{
    public class CsvSeedDataReader : ICsvSeedDataReader
    {
        public SeedData ReedSeedData<TModel>(string filePath) where TModel : class, new()
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader))
            {
                csv.Read();
                csv.ReadHeader();
                var headers = csv.Context.HeaderRecord;
                var records = csv.GetRecords<TModel>();
                var objects = GetObjects(records);

                return new SeedData(headers, objects);
            }
        }

        private object[,] GetObjects<TModel>(IEnumerable<TModel> records) where TModel : class, new()
        {
            var recordsArray = records.ToArray();
            var propertiesCount = CountTypeProperties(typeof(TModel));
            var recordsCount = recordsArray.Length;
            var resultObjects = new object[recordsCount, propertiesCount];

            for (int i = 0; i < recordsCount; i++)
            {
                var propertiesArray = DictionaryFromType(recordsArray[i]).Values.ToArray();
                for (int j = 0; j < propertiesCount; j++)
                {
                    // TODO add header and property name coparison
                    resultObjects[i, j] = propertiesArray[j];
                }

            }

            return resultObjects;
        }

        private int CountTypeProperties(Type type) => type.GetProperties().Length;

        private Dictionary<string, object> DictionaryFromType(object objectType)
        {
            if (objectType == null)
            {
                return new Dictionary<string, object>();
            }

            var props = objectType.GetType().GetProperties();
            var dict = new Dictionary<string, object>();
            foreach (var prp in props)
            {
                var value = prp.GetValue(objectType, new object[] { });
                dict.Add(prp.Name, value);
            }
            return dict;
        }
    }
}
