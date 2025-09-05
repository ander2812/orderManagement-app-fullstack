using AutoMapper;
using OrderManagement.Application.Dtos;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Mappings
{
    public class ShipperProfile : Profile
    {
        public ShipperProfile()
        {
            CreateMap<Shipper, ShipperDto>().ReverseMap();
        }
    }
}
