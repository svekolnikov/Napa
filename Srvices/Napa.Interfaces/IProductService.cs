using Napa.DTO;

namespace Napa.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancel = default);
        Task CreateAsync(ProductCreateEditDto dto, CancellationToken cancel = default);
        Task<ProductCreateEditDto> GetProductByIdAsync(int id, CancellationToken cancel = default);
        Task UpdateProductAsync(ProductCreateEditDto dto, CancellationToken cancel = default);
        Task<bool> DeleteProductAsync(int id, CancellationToken cancel = default);
        decimal GetTotalPriceWithVat(int amount, decimal price);
    }
}