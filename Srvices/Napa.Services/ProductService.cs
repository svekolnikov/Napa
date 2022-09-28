using Microsoft.Extensions.Options;
using Napa.DTO;
using Napa.DTO.Options;
using Napa.Interfaces;


namespace Napa.Services
{
    public class ProductService : IProductService
    {
        private readonly IOptions<ConfigDetails> _config;

        public ProductService(IOptions<ConfigDetails> config)
        {
            _config = config;

            //VAT
            var var = _config.Value.VAT;
        }
        public async Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancel = default)
        {
            //Here we can use Repository
            var vm = new List<ProductDto>
            {
                new(){Id = 1, Price = 345345, Quantity = 5, Title = "Samsung", PriceWithVat = 435345},
                new(){Id = 2, Price = 45345, Quantity = 2, Title = "LG", PriceWithVat = 547452},
            };
            return vm;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateProductAsync(ProductDto dto, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteProductAsync(int id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}