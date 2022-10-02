using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Napa.MVC.ViewModels
{
    public class ProductCreateEditViewModel
    {
        public int Id { get; set; }

        [DisplayName("Title")]
        [StringLength(20, ErrorMessage = "Name length can't be more than 20.")]
        public string Title { get; set; } = null!;

        [DisplayName("Price")]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
