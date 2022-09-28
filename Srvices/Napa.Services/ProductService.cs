using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Napa.DAL.Context;
using Napa.Domain.Entities;
using Napa.DTO;
using Napa.DTO.Options;
using Napa.Interfaces;
using Npgsql.TypeMapping;


namespace Napa.Services
{
    public class ProductService : IProductService
    {
        private readonly IOptions<ConfigDetails> _config;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(IOptions<ConfigDetails> config, ApplicationDbContext dbContext, IMapper mapper)
        {
            _config = config;
            _dbContext = dbContext;
            _mapper = mapper;

            //VAT
            //var vat = _config.Value.VAT;
        }
        public async Task<IEnumerable<ProductDto>> GetAllAsync(CancellationToken cancel = default)
        {
            //Here we can use Repository
            var products = await _dbContext.Products.ToListAsync(cancel);
            var dtos = _mapper.Map<List<ProductDto>>(products);
            return dtos;
        }

        public async Task CreateAsync(ProductDto dto, CancellationToken cancel = default)
        {
            var product = _mapper.Map<Product>(dto);
            await _dbContext.Set<Product>().AddAsync(product, cancel).ConfigureAwait(false);
            await _dbContext.SaveChangesAsync(cancel);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id, CancellationToken cancel = default)
        {
            var product = await _dbContext.Products.SingleOrDefaultAsync(x => x.Id == id, cancel);
            var dto = _mapper.Map<ProductDto>(product);
            return dto;
        }
        
        public async Task UpdateProductAsync(ProductDto dto, CancellationToken cancel = default)
        {
            var product = _mapper.Map<Product>(dto);
            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(cancel).ConfigureAwait(false);
        }

        public async Task<bool> DeleteProductAsync(int id, CancellationToken cancel = default)
        {
            var entity = await _dbContext.Set<Product>()
                .FirstOrDefaultAsync(item => item.Id == id, cancel).ConfigureAwait(false);
            if (entity is null)
            {
                return false;
            }
            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync(cancel);

            return true;
        }
    }
}