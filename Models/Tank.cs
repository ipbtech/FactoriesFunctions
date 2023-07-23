using FactoriesFunctions.Models.Intefaces;

namespace FactoriesFunctions.Models
{
    public class Tank : IBaseElement
    {
        /// <summary>
        /// Резервуар
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Volume { get; set; }
        public int MaxVolume { get; set; }
        public int UnitId { get; set; }
        public override string ToString()
        {
            return $"Id:{Id}, {Name}, {Description}, UnitId:{UnitId}";
        }
    }
}
