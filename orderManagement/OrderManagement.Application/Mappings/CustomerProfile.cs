using AutoMapper;
using OrderManagement.Application.Dtos;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Mappings
{
    public class CustomerProfile: Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
