using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EFCoreSeedMigrations.CsvImport
{
    public class CsvSeedDataReader : ICsvSeedDataReader
    {
        public (string[], object[,]) ReedSeedData<TModel>(string filePath) where TModel : class, new()
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader))
            {
                csv.ReadHeader();
                var headers = csv.Context.HeaderRecord;
                var records = csv.GetRecords<TModel>();
                var objects = GetObjects(records);
                return (headers, objects);
            }
        }

        private object[,] GetObjects<TModel>(IEnumerable<TModel> records) where TModel : class, new()
        {
            var recordsArray = records.ToArray();
            var propertiesCount = CountTypeProperties(typeof(TModel));
            var recordsCount = records.Count();
            var resultObjects = new object[recordsCount, propertiesCount];

            for (int i = 0; i < recordsCount; i++)
            {
                var propertiesArray = DictionaryFromType(recordsArray[i]).Values.ToArray();
                for (int j = 0; j < propertiesCount; j++)
                {
                    resultObjects[i, j] = propertiesArray[j];
                }

            }

            return resultObjects;
        }

        private int CountTypeProperties(Type type) => type.GetProperties().Length;

        private Dictionary<string, object> DictionaryFromType(object atype)
        {
            if (atype == null)
            {
                return new Dictionary<string, object>();
            }

            var props = atype.GetType().GetProperties();
            var dict = new Dictionary<string, object>();
            foreach (var prp in props)
            {
                var value = prp.GetValue(atype, new object[] { });
                dict.Add(prp.Name, value);
            }
            return dict;
        }
    }
}
