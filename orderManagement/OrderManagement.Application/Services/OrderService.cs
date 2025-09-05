using AutoMapper;
using OrderManagement.Application.Dtos;
using OrderManagement.Application.Interfaces.Context;
using OrderManagement.Application.Interfaces.Repositories;
using OrderManagement.Application.Interfaces.Services;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Services
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUserContext _user;

        public OrderService(IOrderRepository repo, IMapper mapper, IUserContext user)
        {
            _repo = repo;
            _mapper = mapper;
            _user = user;
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {

            if (_user.IsInRole("Customer"))
            {
                if (!_user.CustomerId.HasValue)
                    return Enumerable.Empty<OrderDto>();

                var order = await _repo.GetOrdersByCustomerIdAsync(_user.CustomerId.Value);
                return _mapper.Map<IEnumerable<OrderDto>>(order);
            }

            var orders = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto?> GetByIdAsync(int id)
        {
            var order = await _repo.GetByIdAsync(id);
            return order is null ? null : _mapper.Map<OrderDto>(order);
        }

        public async Task AddAsync(OrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);

            await _repo.AddOrderWithDetailsAsync(order);
        }

        public async Task UpdateAsync(OrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            await _repo.UpdateAsync(order);
        }

        public async Task DeleteAsync(int id) =>
            await _repo.DeleteAsync(id);

        public async Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _repo.GetOrdersByCustomerIdAsync(customerId);
        }
    }
}
