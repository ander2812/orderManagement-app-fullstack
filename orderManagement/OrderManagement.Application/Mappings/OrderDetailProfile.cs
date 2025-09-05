using AutoMapper;
using OrderManagement.Application.Dtos;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Mappings
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
        }
    }
}
