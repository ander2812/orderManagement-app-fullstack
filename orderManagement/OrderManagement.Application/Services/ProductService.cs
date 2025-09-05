using AutoMapper;
using OrderManagement.Application.Dtos;
using OrderManagement.Domain.Entities;
using OrderManagement.Application.Interfaces.Repositories;
using OrderManagement.Application.Interfaces.Services;

namespace OrderManagement.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            return product is null ? null : _mapper.Map<ProductDto>(product);
        }

        public async Task AddAsync(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _repo.AddAsync(product);
        }

        public async Task UpdateAsync(ProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _repo.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id) =>
            await _repo.DeleteAsync(id);
    }
}
