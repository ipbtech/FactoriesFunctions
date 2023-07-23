using FactoriesFunctions.Models;
using FactoriesFunctions.Models.Intefaces;
using System.Globalization;
using System.Text.Json;

namespace FactoriesFunctions
{
    public static class CreateManager
    {
        public static IEnumerable<IBaseElement> SimpleCreator()
        {
            var objects = new List<IBaseElement>() 
            {
                #region Factories
                new Factory()
                {
                    Id = 1,
                    Name = "НПЗ№1",
                    Description = "Первый нефтеперерабатывающий завод"
                },
                new Factory()
                {
                    Id = 2,
                    Name = "НПЗ№2",
                    Description = "Второй нефтеперерабатывающий завод"
                },
                #endregion
                #region Units
                new Unit()
                {
                    Id = 1,
                    Name = "ГФУ-2",
                    Description = "Газофракционирующая установка",
                    FactoryId = 1
                },
                new Unit()
                {
                    Id = 2,
                    Name = "АВТ-6",
                    Description = "Атмосферно-вакуумная трубчатка",
                    FactoryId = 1
                },
                new Unit()
                {
                    Id = 3,
                    Name = "АВТ-10",
                    Description = "Атмосферно-вакуумная трубчатка",
                    FactoryId = 2
                },
                #endregion
                #region Tanks
                new Tank()
                {
                    Id = 1,
                    Name = "Резервуар 1",
                    Description = "Надземный - вертикальный",
                    Volume = 1500,
                    MaxVolume = 2000,
                    UnitId = 1
                },
                new Tank()
                {
                    Id = 2,
                    Name = "Резервуар 2",
                    Description = "Надземный - горизонтальный",
                    Volume = 2500,
                    MaxVolume = 3000,
                    UnitId = 1
                },
                new Tank()
                {
                    Id = 3,
                    Name = "Дополнительный резервуар 24",
                    Description = "Надземный - горизонтальный",
                    Volume = 3000,
                    MaxVolume = 3000,
                    UnitId = 2
                },
                new Tank()
                {
                    Id = 4,
                    Name = "Резервуар 35",
                    Description = "Надземный - вертикальный",
                    Volume = 3000,
                    MaxVolume = 3000,
                    UnitId = 2
                },
                new Tank()
                {
                    Id = 5,
                    Name = "Резервуар 47",
                    Description = "Подземный - двустенный",
                    Volume = 4000,
                    MaxVolume = 5000,
                    UnitId = 2
                },
                new Tank()
                {
                    Id = 6,
                    Name = "Резервуар 256",
                    Description = "Подводный",
                    Volume = 500,
                    MaxVolume = 500,
                    UnitId = 3
                }
                #endregion
            };
            return objects;
        }
        public static IEnumerable<T> CreatorByJson<T>(string filename)
        {
            var objects = new List<T>();
            using (FileStream fs = File.OpenRead(filename))
            {
                var data = JsonSerializer.Deserialize<T[]>(fs);
                objects.AddRange(data);
            }
            return objects;
        }
    }
}
