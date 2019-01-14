using System;
using System.IO;
using System.Reflection;

namespace EFCoreSeedMigrations.CsvImport.Tests.TestFilesHelper
{
    public static class AssemblyHelper
    {
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
