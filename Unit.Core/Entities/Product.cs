

namespace Unit.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) && Price > 0;
        }
    }
}