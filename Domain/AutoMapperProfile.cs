using AutoMapper;
using Domain.DTO_s;
using Domain.Entities;

namespace Domain
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<Position, PositionDTO>().ReverseMap();

            CreateMap<EmployeeDTO, DepartmentDTO>().ReverseMap();
            CreateMap<EmployeeDTO, PositionDTO>().ReverseMap();
        }
    }
}
