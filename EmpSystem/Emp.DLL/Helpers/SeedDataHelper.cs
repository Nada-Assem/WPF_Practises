using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emp.DLL.Helpers
{
    public static class SeedDataHelper
    {
        public static List<T> LoadSeedData<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Seed data file not found: {filePath}");
            }

            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonData);
        }
    }
}
