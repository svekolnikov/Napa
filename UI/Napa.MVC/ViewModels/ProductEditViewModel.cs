namespace Napa.MVC.ViewModels
{
    public class ProductEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
