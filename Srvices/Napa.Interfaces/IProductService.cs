using Napa.DTO;

namespace Napa.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancel = default);
        Task<ProductDto> GetProductByIdAsync(int id, CancellationToken cancel = default);
        Task UpdateProductAsync(ProductDto dto, CancellationToken cancel = default);
        Task DeleteProductAsync(int id, CancellationToken cancel = default);
    }
}