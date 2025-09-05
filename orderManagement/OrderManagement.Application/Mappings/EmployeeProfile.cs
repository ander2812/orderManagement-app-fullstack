using AutoMapper;
using OrderManagement.Application.Dtos;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Mappings
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
