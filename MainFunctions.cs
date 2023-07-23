using FactoriesFunctions.Models;
using FactoriesFunctions.Models.Intefaces;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace FactoriesFunctions
{
    public static class MainFunctions
    {
        public static IEnumerable<IBaseElement> GetFactoriesFromBaseCollections(IEnumerable<IBaseElement> baseCollection)
        {
            return baseCollection.Where(el => el.GetType() == typeof(Factory));
        }
        public static IEnumerable<IBaseElement> GetUnitsFromBaseCollections(IEnumerable<IBaseElement> baseCollection)
        {
            return baseCollection.Where(el => el.GetType() == typeof(Unit));
        }
        public static IEnumerable<IBaseElement> GetTanksFromBaseCollections(IEnumerable<IBaseElement> baseCollection)
        {
            return baseCollection.Where(el => el.GetType() == typeof(Tank));
        }
        public static int GetTotalVolume(IEnumerable<Tank> tanks)
        {
            int totalVolume = tanks.Select(el => el.Volume).Sum();
            return totalVolume;
        }

        public static void JsonExporter<T>(IEnumerable<T> collection, string filename)
        {
            var data = JsonSerializer.Serialize(collection, _options);
            File.WriteAllText(filename, data);
            Console.WriteLine(data);
        }
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions()
        {
            AllowTrailingCommas = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            WriteIndented = true
        };
    }
}
