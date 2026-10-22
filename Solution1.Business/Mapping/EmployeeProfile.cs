using AutoMapper;
using Solution1.Business.Dtos.DepartmentDto;
using Solution1.Business.Dtos.EmployeeDto;
using Solution1.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution1.Business.Mapping;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeReturnDto>();
        CreateMap<EmployeeCreateDto, Employee>();
        CreateMap<EmployeeUpdateDto, Employee>();
    }
}
