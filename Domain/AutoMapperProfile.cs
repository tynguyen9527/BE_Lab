using AutoMapper;
using Common.Paganation;
using Domain.DTO_s;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<Position, PositionDTO>().ReverseMap();
            CreateMap<Paganation<EmployeeDTO>, SerachPaganationDTO<EmployeeDTO>>().ReverseMap();
            CreateMap<List<Employee>, List<EmployeeDTO>>().ReverseMap();
        }
    }
}
