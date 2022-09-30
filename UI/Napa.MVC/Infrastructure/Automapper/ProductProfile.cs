using AutoMapper;
using Napa.Domain.Entities;
using Napa.DTO;
using Napa.MVC.ViewModels;

namespace Napa.MVC.Infrastructure.Automapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductDto, ProductViewModel>();
            CreateMap<ProductCreateEditViewModel, ProductDto>();
        }
    }
}
