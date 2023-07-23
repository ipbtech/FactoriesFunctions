using FactoriesFunctions.Models.Intefaces;

namespace FactoriesFunctions.Models
{
    public class Unit : IBaseElement
    {
        /// <summary>
        /// Установка
        /// </summary>
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FactoryId { get; set; }
        public override string ToString()
        {
            return $"Id:{Id}, {Name}, {Description}, FactoryId:{FactoryId}";
        }
    }
}
