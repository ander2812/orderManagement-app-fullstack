using AutoMapper;
using OrderManagement.Application.Dtos;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
