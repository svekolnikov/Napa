namespace Napa.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal PriceWithVat { get; set; }
    }
}