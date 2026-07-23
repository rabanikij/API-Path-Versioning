using AutoMapper;
using DemoEmployeeApiVersioning.Application.Helpers;
using DemoEmployeeApiVersioning.Domain.Entities;

namespace DemoEmployeeApiVersioning.Application.Mapping;


public sealed class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<Employee, DTOs.V1.EmployeeDto>()
            .ForMember(x => x.Name, o => o.MapFrom(s => s.FullName));

        CreateMap<Employee, DTOs.V2.EmployeeDto>();

        CreateMap<Employee, DTOs.V3.EmployeeDto > ();
    }
}
