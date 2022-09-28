using System.ComponentModel;

namespace Napa.MVC.ViewModels
{
    public class ProductViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; } = null!;

        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [DisplayName("Price")]
        public decimal Price { get; set; }

        [DisplayName("Total price with VAT")]
        public decimal PriceWithVat { get; set; }
    }
}
