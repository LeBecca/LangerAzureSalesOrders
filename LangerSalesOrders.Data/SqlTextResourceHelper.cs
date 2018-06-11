using System.IO;
using System.Reflection;
using System.Linq;
using System;

namespace LangerSalesOrders.Data
{
    public static class SqlTextResourceHelper
    {
        private static Assembly DataAssembly { get; set; }
        private static string[] ResourceNames { get; set; }

        static SqlTextResourceHelper()
        {
            DataAssembly = typeof(SqlTextResourceHelper).Assembly;
            ResourceNames = DataAssembly.GetManifestResourceNames();
        }

        public static string GetTextResource(string resourceName)
        {
            string result = string.Empty;

            if (string.IsNullOrEmpty(resourceName))
            {
                return result;
            }

            resourceName = $"{resourceName}.sql";

            var fullMatchingResourceNames = ResourceNames.Where(name => name.EndsWith(resourceName));

            if (fullMatchingResourceNames.Count() == 0)
            {
                throw new ArgumentException();
            }

            if (fullMatchingResourceNames.Count() > 1)
            {
                throw new AmbiguousMatchException();
            }

            using (Stream stream = DataAssembly.GetManifestResourceStream(fullMatchingResourceNames.First()))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }


            return result;
        }
    }
}
