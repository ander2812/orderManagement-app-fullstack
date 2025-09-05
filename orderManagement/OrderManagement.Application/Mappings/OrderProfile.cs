using AutoMapper;
using OrderManagement.Application.Dtos;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Mappings
{
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>()
            .ForMember(dest => dest.orderid, opt => opt.Ignore());

            CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.OrderId, opt => opt.Ignore());
        }
    }
}
