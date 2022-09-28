namespace Napa.Domain.Entities
{
    public class Product : Entity
    {
        public string Title { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}