using FactoriesFunctions;
using FactoriesFunctions.Models;
using FactoriesFunctions.Models.Intefaces;

var allElsBySimpleCreator = CreateManager.SimpleCreator();
var factoriesBySimpleCreator = MainFunctions.GetFactoriesFromBaseCollections(allElsBySimpleCreator).Cast<Factory>();
var unitsBySimpleCreator = MainFunctions.GetUnitsFromBaseCollections(allElsBySimpleCreator).Cast<Unit>();
var tanksBySimpleCreator = MainFunctions.GetTanksFromBaseCollections(allElsBySimpleCreator).Cast<Tank>();

#region Задание 1
// Вернуть количество всех объектов указанных в задании объектов
Console.WriteLine($"Количество заводов: {factoriesBySimpleCreator.Count()}, количество установок: {unitsBySimpleCreator.Count()}, " +
    $"количество резервуаров: {tanksBySimpleCreator.Count()} \n" +
    $"Общее количество всех объектов:{allElsBySimpleCreator.Count()}");
Console.WriteLine();
#endregion

#region Задание 2
// Реализовать методы, которые:
//    - возращает установку (Unit), которой принадлежит резервуар (Tank), 
//    - возвращает объект завода, соответствующий установке (Unit)
var foundUnit = tanksBySimpleCreator.FindUnit(unitsBySimpleCreator, "Резервуар 256");
var foundFactory = factoriesBySimpleCreator.FindFactory(foundUnit);
Console.WriteLine($"Установка {foundUnit.Name} принадлежит заводу {foundFactory.Name}");
Console.WriteLine();
#endregion

#region Задание 3
// Реализовать метод, возращающий суммарный объекм всех резервуаров в массиве
var totalVolume = MainFunctions.GetTotalVolume(tanksBySimpleCreator);
Console.WriteLine($"Суммарный объем резервуаров: {totalVolume}");
Console.WriteLine();
#endregion

#region Задание 4
// Осуществить вывод в консоль всех резервуаров, включая имена цеха и фабрики, в которых они числятся
var tanksData = tanksBySimpleCreator.Join(unitsBySimpleCreator, tank => tank.UnitId, unit => unit.Id, (tank, unit) => new
{
    TankName = tank.Name,
    MaxVolume = tank.MaxVolume,
    UnitName = unit.Name,
    FactoryId = unit.FactoryId
}).Join(factoriesBySimpleCreator, tankInUnit => tankInUnit.FactoryId, factory => factory.Id, (tankInUnit, factory) => new
{
    TankName = tankInUnit.TankName,
    MaxVolume = tankInUnit.MaxVolume,
    UnitName = tankInUnit.UnitName,
    FactoryName = factory.Name
});

foreach (var item in tanksData)
{
    Console.WriteLine($"Резервуар {item.TankName} максимальной мощностью {item.MaxVolume} принадлежит установке {item.UnitName}, которая находится на заводе {item.FactoryName}");
}
Console.WriteLine();
#endregion

#region Задание 5
// Экспорт всех элементов в json
MainFunctions.JsonExporter<Factory>(factoriesBySimpleCreator, "factories.json");
MainFunctions.JsonExporter<Unit>(unitsBySimpleCreator, "units.json");
MainFunctions.JsonExporter<Tank>(tanksBySimpleCreator, "tanks.json");
Console.WriteLine();
#endregion

#region Задание 6
// Создание всех элементов из файлов json
var allElsByJsonCreator = new List<IBaseElement>();
allElsByJsonCreator.AddRange(CreateManager.CreatorByJson<Factory>("factories.json"));
allElsByJsonCreator.AddRange(CreateManager.CreatorByJson<Unit>("units.json"));
allElsByJsonCreator.AddRange(CreateManager.CreatorByJson<Tank>("tanks.json"));
foreach (var item in allElsByJsonCreator)
{
    Console.WriteLine(item);
}
#endregion



public static class Extensions
{
    public static Unit FindUnit(this IEnumerable<Tank> tanks, IEnumerable<Unit> units, string tankName)
    {
        Unit result = null;
        var tank = tanks.FirstOrDefault(tank => tank.Name == tankName);
        if (tank != null)
        {
            result = units.FirstOrDefault(unit => unit.Id == tank.UnitId);
        }
        return result;
    }
    public static Factory FindFactory(this IEnumerable<Factory> factories, Unit unit)
    {
        var result = factories.FirstOrDefault(factory => factory.Id == unit.FactoryId);
        return result;
    }
}