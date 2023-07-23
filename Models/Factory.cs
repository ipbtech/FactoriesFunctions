using FactoriesFunctions.Models.Intefaces;

namespace FactoriesFunctions.Models
{
    /// <summary>
    /// Завод
    /// </summary>
    public class Factory : IBaseElement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            return $"Id:{Id}, {Name}, {Description}";
        }
    }
}
