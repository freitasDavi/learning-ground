

namespace Unit.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}