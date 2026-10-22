using AutoMapper;
using Solution1.Business.Dtos.DepartmentDto;
using Solution1.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solution1.Business.Mapping;

public class DepartmentProfile : Profile
{
    public DepartmentProfile()
    {
        CreateMap<Department, DepartmentReturnDto>();
        CreateMap<DepartmentCreateDto, Department>();
        CreateMap<DepartmentUpdateDto, Department>();
    }
}
